    interface IWork
    {
        void Run(object input);
    }
    class ImmediateWork : IWork
    {
        public void Run(object input)
        {
            // Code to run immediately (without schedule).
        }
    }
    class ScheduledWork : IWork, IJob
    {
        public void Run(object input)
        {
            // Create the schedule for the 'Execute' method.
            var job = JobBuilder.Create<ScheduledWork>().Build();
            var schedule = SimpleScheduleBuilder.RepeatHourlyForTotalCount(10);
            var trigger = TriggerBuilder.Create().WithSchedule(schedule).StartNow().Build();
            ScheduleManager.Instance.ScheduleJob(job, trigger);
        }
        public void Execute(IJobExecutionContext context)
        {
            // Code to run after some time (with schedule).
        }
    }
    // Simple singleton implementation of the global scheduler, for demonstration purposes only.
    static class ScheduleManager
    {
        private static IScheduler _instance;
        public static IScheduler Instance => _instance ?? (_instance = createInstance());
        private static IScheduler createInstance()
        {
            // Create the instance of the scheduler.
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler();
            // Start the scheduler.
            if (!scheduler.IsStarted)
                scheduler.Start();
            return scheduler;
        }
    }
