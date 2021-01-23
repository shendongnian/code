    using UnityEngine;    
    using UnityEngine.UI;   
    using System;   
    using System.Collections;  
    **using UnityEngine.SceneManagement;**
    public class UIManager : MonoBehaviour{
    public void OnRoomJoin(BaseEvent e)
    	{   
       		// Remove SFS2X listners and re-enable interface before moving to the main game scene
    		//Reset();
    		// Goto the main game scene
    		**SceneManager.LoadScene(1);**
    //     **SceneManager.LoadScene("main");**  
    	}   
    }
