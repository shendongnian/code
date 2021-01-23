    protected override void OnStart(string[] args)
    {
        base.OnStart(args);
        //my stuff
        this.WriteEventLogEntry("My service started successfully", System.Diagnostics.EventLogEntryType.Information);
    }
