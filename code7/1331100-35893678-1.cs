    public void BeginTracking(ITracker tracker)
    {
        IDemarcatedTracker demarcatedTracker = tracker as IDemarcatedTracker;
        if (demarcatedTracker != null)
            demarcatedTracker.BeginTracking();
    }
