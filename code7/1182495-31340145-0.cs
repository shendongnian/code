        using Quartz;
        private ScheduleCopyTask()
        {
            Quartz.IScheduler sched;
            IJobDetail job;
            ITrigger trigger;
            // Instantiate the Quartz.NET scheduler
            var schedulerFactory = new Quartz.Impl.StdSchedulerFactory();
            sched = schedulerFactory.GetScheduler();
            sched.Start();
            // Instantiate the JobDetail object passing in the type of your
            // custom job class. Your class merely needs to implement a simple
            // interface with a single method called "Execute".
            job = JobBuilder.Create<SyncJob>()
                         .WithIdentity("SyncJob", "group1").Build();
            // Trigger the job to run now, and then every 30 mins
            trigger = TriggerBuilder.Create()
             .WithIdentity("SyncTrigger", "group1")
             .StartNow()
             .WithSimpleSchedule(x => x
             .WithIntervalInMinutes(30)
             .RepeatForever()).Build();
            sched.ScheduleJob(job, trigger);
        }
