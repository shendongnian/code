    public void Run(IBackgroundTaskInstance taskInstance)
    {
        var control = BackgroundMediaPlayer.Current.SystemMediaTransportControls;
        control.ButtonPressed += control_ButtonPressed;
        ...
    }
