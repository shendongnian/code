    if (RawInputHandler == null)
    {
        RawInputHandler = RawInput.Instance;
                    
        RawInputHandler.LoggingEvent += RawInputHandler_LoggingEvent;
        RawInputHandler.KeyPressed += RawInputHandler_KeyPressed;
        RawInputHandler.MousePressed += RawInputHandler_MousePressed;
    }
