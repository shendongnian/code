    private ISchedulerFactory _schedulerFactory;
    private IScheduler _scheduler;
    protected override void OnStart(string[] args)
    {
        _schedulerFactory = new StdSchedulerFactory();
        _scheduler = _schedulerFactory.GetScheduler();
        _scheduler.Start();
        IJobDetail syncJob = JobBuilder.Create<MySyncJob>()
            .WithIdentity("syncJob")
            .Build();
        ITrigger trigger = TriggerBuilder.Create()
            .StartAt(new DateTimeOffset(DateTime.UtcNow.AddSeconds(5)))
            .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
            .Build();
        scheduler.ScheduleJob(syncJob, trigger);
    }
    protected override void OnStop()
    {
        // true parameter indicates whether to wait for running jobs
        // to complete before completely tearing down the scheduler
        // change to false to force running jobs to abort.
        _scheduler.Shutdown(true);
    }
