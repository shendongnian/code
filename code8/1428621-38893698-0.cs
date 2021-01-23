    public class ReminderJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var dataMap = context.Trigger.JobDataMap;
            var originalActivity = dataMap["originalActivity"] as Activity;
            var message = dataMap["reply"] as string;
            if (originalActivity == null) return;
            var connector = new ConnectorClient(new Uri(originalActivity.ServiceUrl));
            var reply = originalActivity.CreateReply(message);
            connector.Conversations.ReplyToActivity(reply);
        }
    }
    public class JobScheduler
    {
        public static void StartReminderJob(ITrigger trigger)
        {
            var scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            var job = JobBuilder.Create<ReminderJob>().Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }
