    bool initialFocus;
    void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
        {
            //App became active, will fire on application start
        }
        if (focusStatus && initialFocus)
        {
            //App became active, after it's been inactive at least once
        }
        initialFocus = initialFocus || focusStatus;
    }
