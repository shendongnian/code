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
            nac.UserClickedPauseButton(); // And remember to call this again here, so animation is unpaused when tutorialModal is not active.
            paused = false;
        }
    }
