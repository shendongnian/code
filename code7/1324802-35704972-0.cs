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
            paused = false;
        }
    }
