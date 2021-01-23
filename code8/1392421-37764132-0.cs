    public GameObject pauseMenu;
    bool isPaused = false;
     void Awake()
     {
         if (Application.loadedLevelName != "Start_Menu")
         {
             Cursor.lockState = CursorLockMode.Locked;
             Cursor.visible = false;
             pauseMenu.SetActive(false);
             Debug.Log(isPaused + " " + pauseMenu);
         }
     }
