    using Quartz;
    public class EmailJob : IJob
  	{
		public void Execute(IJobExecutionContext context)
		{
			SendEmail();
  	    }
	}
