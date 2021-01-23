    void Update()
    {
        Debug.Log ( Time.timeSinceLevelLoad );
        if ( Time.timeSinceLevelLoad > 10 )
        {
             System.Environment.Exit(0);
        }
    }
