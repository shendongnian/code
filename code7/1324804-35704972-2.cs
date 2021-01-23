    bool paused = false;
    public void Update()
    {
        if (tutorialModal.activeInHierarchy == true && !paused)
        {
            Debug.Log("The tutorial panel is active!!");
            nac.UserClickedPauseButton();
            paused = true;
        }
        else if(tutorialModal.activeInHierarchy == false && paused)
        {
            Debug.Log("The tutorial panel is not active, I repeat NOT ACTIVE!");
            
            // And remember to call UserClickedPauseButton here too, 
            // so animation is unpaused when tutorialModal is not active.
            nac.UserClickedPauseButton(); 
            paused = false;
        }
    }
