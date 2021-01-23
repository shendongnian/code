    public class SampleJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            context.Scheduler.Shutdown();
        }
    }
