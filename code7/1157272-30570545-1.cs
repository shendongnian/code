    protected void scheduleTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (nextRun < DateTime.Now)
        {
            nextRun = GetNextRun(DateTime.Now);
            ServiceEmailMethod();
        }
    }
