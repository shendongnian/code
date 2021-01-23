      [PersistJobDataAfterExecution]
        [DisallowConcurrentExecution]
        public class SecondJob : IJob        /* : IStatefulJob */ /* Error	43	'Quartz.IStatefulJob' is obsolete: 'Use DisallowConcurrentExecutionAttribute and/or PersistJobDataAfterExecutionAttribute annotations instead. */
        {
    
            public virtual void Execute(IJobExecutionContext context)
            {
                string msg = string.Empty;
                /*
                 * stateful jobs are not allowed to execute concurrently, which means new triggers that occur before the completion of the execute(xx) method will be delayed.
                 * */
    
                JobKey key = context.JobDetail.Key;
    
                Console.WriteLine(string.Empty);
                msg = string.Format("Start : SecondJob : JobKey='{0}' at '{1}'", key, DateTime.Now.ToLongTimeString());
                Console.WriteLine(msg);
    
    	string firstJob_JobKey = string.Empty; /* read from a .config file or other way to get it, do not hard code it) */
    					
                try
                {
    				
    										if(null!=context)
    					{
    							if(null!=context.Scheduler)
    							{
    								context.Scheduler.PauseJob(firstJob_JobKey);
    							}
    					}
    					
    					/* now call code to actually do the job stuff , which would be a common library that both FirstJob and SEcondJob code share to avoid duplicate coding */
    					
                }
                catch (ThreadInterruptedException)
                {
                }
    			finally
    			{
    				/* put in finally block so that it will resume....*/
    				try
    				{
    					if(null!=context)
    					{
    							if(null!=context.Scheduler)
    							{
    								if(!string.IsNullOrEmpty(firstJob_JobKey))
    								{
    									context.Scheduler.ResumeJobs(firstJob_JobKey);
    								}
    							}
    					}
    				}
    			}
    
    
                msg = string.Format("End : SecondJob : JobKey='{0}' at '{1}'", key, DateTime.Now.ToLongTimeString());
                Console.WriteLine(msg);
                Console.WriteLine(string.Empty);
    
            }
        }
