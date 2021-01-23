    public static Task<bool> TouchHold(this FrameworkElement element, TimeSpan duration)
    {
        DispatcherTimer timer = new DispatcherTimer();
        TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
        timer.Interval = duration;
    
        MouseButtonEventHandler touchUpHandler = delegate
        {
            timer.Stop();
            if (task.Task.Status == TaskStatus.Running)
            {
                task.SetResult(false);
            }
        };
    
        element.PreviewMouseUp += touchUpHandler;
    
        timer.Tick += delegate
        {
            element.PreviewMouseUp -= touchUpHandler;
            timer.Stop();
            task.SetResult(true);
        };
    
        timer.Start();
        return task.Task;
    }
