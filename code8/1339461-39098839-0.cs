    private bool paused = false;
    //The function called by the button OnClick()
    public void TogglePause()
    {
        paused = !paused;
        if(paused)
            Time.timescale = 0f;
        else
            Time.timescale = 1f;
    }
