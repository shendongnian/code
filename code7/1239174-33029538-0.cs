    private bool levelLoaded = false;
    void OnGUI()
    {
        if (!levelLoaded && GUI.Button(new Rect(-36, 79, 83, 31), "Play"))
        {
            Application.LoadLevel(1);
            levelLoaded = true;
        }
    }
