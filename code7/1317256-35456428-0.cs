    public class Job : IJob
    {
        public Sync1 Sync{get;set;};
        
        public void Execute(IJobExecutionContext context)
        {
              if(Sync!=null)
                  Sync.startSync();
        }
    }
