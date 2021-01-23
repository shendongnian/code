    private void timer_is_working(object source, ElapsedEventArgs e)
    {
        ExecuteSecure(() => aTimer.Enabled = false);        
        ExecuteSecure(() => button1.Enabled = true);
    }
    private void ExecuteSecure(Action action)
    {
        if (InvokeRequired)
        {
            Invoke(new MethodInvoker(() =>
            {
                action();
            }));
        }
        else
        {
            action();
        }
    }
