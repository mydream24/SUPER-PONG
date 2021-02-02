﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public static List<string> sceneHistory = new List<string>();  //running history of scenes

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);  //Allow this object to persist between scene changes
    }

    //Call this whenever you want to load a new scene
    //It will add the new scene to the sceneHistory list
    public static void LoadScene(string newScene)
    {
        sceneHistory.Add(newScene);
        SceneManager.LoadScene(newScene);
    }

    //Call this whenever you want to load the previous scene
    //It will remove the current scene from the history and then load the new last scene in the history
    //It will return false if we have not moved between scenes enough to have stored a previous scene in the history
    public static bool PreviousScene()
    {
        bool returnValue = false;
        if (sceneHistory.Count >= 2)  //Checking that we have actually switched scenes enough to go back to a previous scene
        {
            returnValue = true;
            sceneHistory.RemoveAt(sceneHistory.Count - 1);
            SceneManager.LoadScene(sceneHistory[sceneHistory.Count - 1]);
        }
        //Debug.Log(sceneHistory.Count);

        return returnValue;
    }
}
