    public class ReadCountry : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
           CountryProcessJob.DoIt();
        }
    }
