    void Start()
    {
        //This starts the coroutine.
        StartCoroutine(PauseAndSetFOV());     
    }
    // This is a coroutine.
    private IEnumerator PauseAndSetFOV()
    {
        // This waits for a specified amount of seconds
        yield return new WaitForSeconds(2f);
        // This sets all the cameras FOV's after waiting two seconds.
        for(int i = 0; i < Camera.allCamerasCount; i++)
        {
            Camera.allCameras[i].fieldOfView = 60;
        }
    }
