    class CronJobScheduler : IScheduledJob
    {
        public IScheduler Run()
        {
            var schd = GetScheduler();
            if (!schd.IsStarted)
                schd.Start();
            var trigger = (ICronTrigger)TriggerBuilder.Create()
                          .WithIdentity("cronjobTrigger", "cronGroup1")
                           .WithCronSchedule("0 0 1 1/1 * ? *")
                          .StartAt(DateTime.UtcNow)
                           .WithPriority(1)
                         .Build();
            var job = JobBuilder.Create<CronJob>()
                        .WithIdentity("cronjob", "cronGroup1")
                        .RequestRecovery()
                        .Build();
            var schedule = schd.ScheduleJob(job, trigger);
            return schd;
        }
      
        // Get an instance of the Quartz.Net scheduler
        private static IScheduler GetScheduler()
        {
            try
            {
                var properties = new NameValueCollection();
                properties["quartz.scheduler.instanceName"] = "ServerScheduler";
                // set remoting expoter
                properties["quartz.scheduler.proxy"] = "true";
                properties["quartz.scheduler.proxy.address"] = string.Format("tcp://{0}:{1}/{2}", "localhost", "555",
                                                                             "QuartzScheduler");
                // Get a reference to the scheduler
                var sf = new StdSchedulerFactory();//properties);
                return sf.GetScheduler();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Scheduler not available: '{0}'", ex.Message);
                throw;
            }
        }
        public void Shutdown(IScheduler schd)
        {
            schd.Shutdown();
        }
    }
