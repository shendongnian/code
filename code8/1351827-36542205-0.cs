    [PersistJobDataAfterExecution]
    [DisallowConcurrentExecution]
    public class PushingJob : IJob
    {
         DataObject _data;
         // with injection
         public PushingJob(DataObject data)
         {
             _data= data;
         }
    
         public void Execute(IJobExecutionContext context)
         {
            var keys = context.Scheduler.GetJobKeys(GroupMatcher<JobKey>.AnyGroup());
    
            foreach (var key in keys)
            {
                var detail = context.Scheduler.GetJobDetail(key);
                if (detail.JobType == typeof(PullingJob))
                {
                    data.MyDict.AddOrUpdate("Foo", "Bar");
                }
            }
        }
    }
    [PersistJobDataAfterExecution]
    [DisallowConcurrentExecution]
    public class PullingJob : IJob
    {
         DataObject _data;
         // with injection
         public PushingJob(DataObject data)
         {
             _data= data;
         }
         public void Execute(IJobExecutionContext context)
         {
            Console.WriteLine("Foo property = " + _data.MyDict.GetOrAdd("Foo"));
         }
    }
