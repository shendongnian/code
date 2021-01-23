    private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
    {
        if (e.Reason == SessionSwitchReason.SessionLock)
        {
            // session was locked
        }
        else if (e.Reason == SessionSwitchReason.SessionUnlock)
        {
            // session was unlocked
        }
    }
