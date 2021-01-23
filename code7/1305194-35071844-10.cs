    using Quartz;
    using Quartz.Impl;
	public class JobScheduler
	{
		public static void Start()
		{
			IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
			scheduler.Start();
			IJobDetail job = JobBuilder.Create<EmailJob>().Build();
			ITrigger trigger = TriggerBuilder.Create()
				.WithIdentity("trigger1", "group1")
				//.StartAt(new DateTime(2015, 12, 21, 17, 19, 0, 0))
				.StartNow()
				.WithSchedule(CronScheduleBuilder
					.WeeklyOnDayAndHourAndMinute(DayOfWeek.Monday, 10, 00)
					//.WithMisfireHandlingInstructionDoNothing() //Do not fire if the firing is missed
					.WithMisfireHandlingInstructionFireAndProceed() //MISFIRE_INSTRUCTION_FIRE_NOW
					.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("GTB Standard Time")) //(GMT+02:00)
					)
				.Build();
			scheduler.ScheduleJob(job, trigger);
		}
	}
