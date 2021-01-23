     public class CronJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var sj = new LiveScheduledJobs();
            var schd = sj.Run();
        }
    }
