    public class MyJobListener : JobListenerSupport
    {
        BlockingQueue<DateTime> _queue;
        public override string Name
        {
            get { return "AllJobListener"; }
        }
        public override void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            if (jobException == null)
            {
                // do whatever you want
            }
            else
            {
                _queue.Add(DateTime.UtcNow);
            }
            base.JobWasExecuted(context, jobException);
        }
    }
