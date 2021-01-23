    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // Place delegate on the Dispatcher. 
        this.Dispatcher.Invoke(DispatcherPriority.Normal,
            new TimerDispatcherDelegate(TimerWorkItem));
    }
