    using Quartz;
    using Quartz.Impl;
    
    public class Scheduler
    {
        private static IScheduler _scheduler;
    
        public static void Start()
        {
            _scheduler = StdSchedulerFactory.GetDefaultScheduler();
            _scheduler.Start();
    
            ITrigger myTrigger = TriggerBuilder.Create()
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInHours(4)
                    .RepeatForever())
                .Build();
    
            IJobDetail myJob = JobBuilder.Create<MyJobClass>().Build();
            _scheduler.ScheduleJob(myJob, myTrigger);
        }
    
        public static void Stop()
        {
            if (_scheduler != null)
            {
                _scheduler.Shutdown();
            }
        }
    }
