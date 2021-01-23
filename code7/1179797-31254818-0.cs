    using UnityEngine;
    using System.Collections;
    
    public class SceneDetector : MonoBehaviour {
    	public int numberOfScenes = 5;
    	public String[] sceneNames;
    	
    	void Start() {
    		sceneNames = new String[numberOfScenes];
    		for(int i = 0; i < numberOfScenes; i++)
    		{
    			sceneNames[i] = Application.GetLevelNameByIndex(i);
    		}
    	}
    	
    	public int GetSceneIndex(String sceneName)
    	{
    		for(int i = 0; i < sceneNames.length; i++)
    		{
    			if(sceneName == sceneNames[i])
    			{
    				return i;
    			}
    		}
    		return -1;
    	}
    }
