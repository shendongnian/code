        public bool EnableEvents;
        public bool ScreenUpdating;
    }
    class Example
    {
        private Stack<ExcelEventSettings> settingStack = new Stack<ExcelEventSettings>();
        // you can call this function as often as you called SaveAppSettings
        public void RestoreAppSettings()
        {
            if (settingStack.Count == 0)
                throw new Exception("There is no previous state!");
            ExcelEventSettings prevState = settingStack.Pop();
            setCurrentEnableEvents(prevState.EnableEvents);
            setCurrentScreenUpdating(prevState.ScreenUpdating);
        }
        public void SetAppSettings(bool enableEvents, bool screenUpdating)
        {
            ExcelEventSettings currentState;
            currentState.EnableEvents = getCurrentEnableEvents();
            currentState.ScreenUpdating = getCurrentScreenUpdating();
            settingStack.Push(currentState);
            setCurrentScreenUpdating(enableEvents);
            setCurrentEnableEvents(screenUpdating);
        }
        private bool getCurrentEnableEvents()
        {
            return false;
        }
        private bool getCurrentScreenUpdating()
        {
            return false;
        }
        private void setCurrentEnableEvents(bool value)
        {
            // Here you would call your Excel function
        }
        private void setCurrentScreenUpdating(bool value)
        {
            // Here you would call your Excel function
        }
    }
