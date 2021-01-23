    void Start()
    {
        //This starts the coroutine.
        StartCoroutine(PauseAndSetFOV(2f));     
    }
    // This is a coroutine.
    private IEnumerator PauseAndSetFOV(float seconds)
    {
        // This waits for the amount of seconds passed (2 in this case).
        yield return new WaitForSeconds(seconds);
        // This sets all the cameras FOV's after waiting two seconds.
        for(int i = 0; i < Camera.allCamerasCount; i++)
        {
            Camera.allCameras[i].fieldOfView = 60;
        }
    }
