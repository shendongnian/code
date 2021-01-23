    using UnityEngine;
    using System.Collections;
    
    public class pauseMenu : MonoBehaviour 
    {
    	public GUISkin myskin;
    	
    	private Rect windowRect;
    	private bool paused = true , waited = true;
    	private float time = 0;
    	
    	private void Start()
    	{
    		windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200);
    	}
    	
    	private void waiting()
    	{
    		waited = true;
    	}
    
    	private void Update()
    	{
    		if (waited)
    			if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.P))
    		{
    			if (paused)
    				paused = false;
    			else
    				paused = true;
    			
    			waited = false;
    			Invoke("waiting",0.3f);
    		}
    		if(paused)time += Time.deltaTime;
    		Debug.Log (time);
    	}
    	
    	private void OnGUI()
    	{
    		if (paused)
    			windowRect = GUI.Window(0, windowRect, windowFunc, "Pause Menu");
    	}
    	
    	private void windowFunc(int id)
    	{
    		if (GUILayout.Button("Resume"))
    		{
    			paused = false;
    		}
    		if (GUILayout.Button ("Restart")) 
    		{
    			Application.LoadLevel("LEVEL 1");
    		}
    		if (GUILayout.Button("Quit"))
    		{
    			Application.LoadLevel("Main Menu");
    		}
    	}
    }
