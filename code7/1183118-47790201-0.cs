    public static void DoEvents(
        DispatcherPriority priority = DispatcherPriority.Background)
    {
        Dispatcher.CurrentDispatcher.Invoke(new Action(delegate { }), priority);
    }
