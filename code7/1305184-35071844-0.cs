    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<JobBackground>().Build();
            ITrigger trigger = TriggerBuilder.Create()
				.WithIdentity("trigger1", "group1")
				//.StartAt(new DateTime(2015, 12, 21, 17, 19, 0, 0))
				.StartNow()
				.WithSchedule(CronScheduleBuilder
                .DailyAtHourAndMinute(0,0)
					.WithMisfireHandlingInstructionFireAndProceed() //MISFIRE_INSTRUCTION_FIRE_NOW
					.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("GTB Standard Time")) //(GMT+02:00) 
                    //https://alexandrebrisebois.wordpress.com/2013/01/20/using-quartz-net-to-schedule-jobs-in-windows-azure-worker-roles/
					)
				.Build();
			scheduler.ScheduleJob(job, trigger);
        }
    }
