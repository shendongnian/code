    using UnityEngine;
    using System.Collections;
    
    public class pauseMenu : MonoBehaviour 
    {
    	public GUISkin myskin;
    	
    	private Rect windowRect;
    	private bool paused = false , waited = true;
    	private float time = 60f;
    	
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
    		if(!paused)
    			if(time>0)
    				time -= Time.deltaTime;
    	}
    	
    	private void OnGUI()
    	{
    		if (paused)
    			windowRect = GUI.Window(0, windowRect, windowFunc, "Pause Menu");
    		GUI.Box(new Rect(1, 2, 70, 30), "Time: " + time.ToString("0"));
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
