    private static bool _isStarted
    public static void Start()
    {
       if(!_isStarted)
       {
           _isStarted = true;
           ...
       }
    }
    // set to false in Stop()
