    public void InitializeTimer()
    {
        ActivityTimer = new System.Timers.Timer(Configuration.TimeoutSettings["IntervalMilliseconds"]);
        ActivityTimer.AutoReset = true;
        ActivityTimer.Elapsed += OnElapsedPollForActivity;
        ActivityTimer.Start();
    }
    /// <summary>
    /// Method is called in ValidationForm_FormClosing, unsubscribes handler from event and stops the clock.
    /// </summary>
    public void TerminateTimer()
    {
        ActivityTimer.Elapsed -= OnElapsedPollForActivity;
        ActivityTimer.Stop();
    }
    /// <summary>
    /// Fires on ActivityTimer.Elapsed, polls workstation for time since last user input.
    /// </summary>
    private void OnElapsedPollForActivity(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (Tracker.GetIdleTime() > Configuration.TimeoutSettings["TriggerMilliseconds"])
        {
            Logger.LogException(CurrentSession.SessionID, DateTime.Now, new InactivityException("Detected extended period of workstation inactivity."));
            Application.Exit();
        }
    }
