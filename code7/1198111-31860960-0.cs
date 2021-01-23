    public class JobScheduling : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var schd = context.Scheduler;
            scheduleOtherJobs(scheduler);//this is where you schedule the other jobs    
        }
    }
