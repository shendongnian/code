    void Update () {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            audio.Pause();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            audio.UnPause();
        }
    }
