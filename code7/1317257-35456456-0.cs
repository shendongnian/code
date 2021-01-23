    public class Job : IJob
    {
         public void Execute(IJobExecutionContext context)
         {
             MySync.Sync1 form = new MySync.Sync1();
             form.startSync();
         }
    }
