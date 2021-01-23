    public static void DoEvents()
    {
        DispatcherFrame frame = new DispatcherFrame();
        Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(ExitFrame), frame);
        Dispatcher.PushFrame(frame);
    }
    public static object ExitFrame(object f)
    {
        ((DispatcherFrame)f).Continue = false;
        return null;
    }
