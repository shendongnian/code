    /// <summary>
    /// JobChainingJobListener that doesn't run subsequent jobs when one fails.
    /// </summary>
    public class JobChainingJobListenerFailOnError : JobChainingJobListener
    {
    	public JobChainingJobListenerFailOnError(String name) : base(name) { }
    	
    	public override void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
    	{
    		//Only call the base method if jobException is null.  Otherwise, an
    		//error has occurred & we don't want to continue chaining
    		if (jobException == null)
    			base.JobWasExecuted(context, jobException);
    	}
    }
