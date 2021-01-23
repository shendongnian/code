    private void SwitchRuns()
    {
        ThreadPool.QueueUserWorkItem((o) => this.SwitchRuns());
    }
    private void SwitchRunsAsync()
    {
        // Bound property (set up with Notification correctly)
        //
        this.Dispatcher.BeginInvoke((Action)(() =>
        {
            CurRunTextBoxColor = Brushes.Red;
        }), DispatcherPriority.Send);
        // Place your load logic here in place of the sleep.
        Thread.Sleep(2000);
        this.Dispatcher.BeginInvoke((Action)(() =>
        {
            CurRunTextBoxColor = Brushes.LightGreen;
        }), DispatcherPriority.Send);
    }
