    using UnityEngine;
    using System.Collections;
    
    public class Booter : MonoBehaviour
    {
    	void Start ()
    	{
    		Application.targetFrameRate = 30;
    		GameObject obj = GameObject.Find("Globals");
    		if(obj == null)
    		{
    			obj = new GameObject("Globals");
    			GameObject.DontDestroyOnLoad(obj);
    			SharedData sharedData = obj.AddComponent<SharedData>();
    			sharedData.Initialize();
    		}
    	}
    }
