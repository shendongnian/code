    public class Syncclass
    {
          public void startSync()
          { 
                // your staff here
          }           
    }
    public class Job : IJob
    {
       private Syncclass sync = null;
        public void Execute(IJobExecutionContext context)
        {
          sync.startSync();
        }
    
    public Job()
    {
      sync = new Syncclass();
    }
    }
