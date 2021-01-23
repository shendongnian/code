    GameObject pauseMenu;
    bool isPaused = false;
    
     void Start()
     {
         if (Application.loadedLevelName != "Start_Menu")
         {
             Cursor.lockState = CursorLockMode.Locked;
             Cursor.visible = false;
             pauseMenu = GameObject.Find("Canvas_Pause_Menu");
             pauseMenu.SetActive(false);
             Debug.Log(isPaused + " " + pauseMenu);
         }
     }
