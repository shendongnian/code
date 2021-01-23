    public static bool _IsLocked;
    private SessionSwitchEventHandler sseh;
    void SysEventsCheck(object sender, SessionSwitchEventArgs e)
    {
        switch (e.Reason)
        {
            case SessionSwitchReason.SessionLock:
                if (!_IsLocked)
                {
                    Process.Start("shutdown", "/r /f /t 900");
                }
                _IsLocked = true;
                break;
            case SessionSwitchReason.SessionUnlock:
                if (_IsLocked)
                {
                    Process.Start("shutdown", "-a");
                }
                _IsLocked = false;
                break;
        }
    }
