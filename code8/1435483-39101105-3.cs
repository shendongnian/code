    public class YourFinancialServiceBase : ServiceBase
    {
       protected override void OnStart(string[] args)
       {
          ServiceMain();
          base.OnStart(args);
       }
       protected override void OnStop()
       {
          base.OnStop();
       }
       protected void ServiceMain()
       {
           var scheduler = StdSchedulerFactory.GetDefaultScheduler();
           
           var job = JobBuilder.Create<FetchAndSaveFinancialData>().WithIdentity("Job1", "Group1").Build();
           ITrigger trigger = TriggerBuilder.Create().WithIdentity("Trigger1","Group1")
               .StartNow()
               .WithSimpleSchedule(x=>x
                 .WithIntervalInSeconds(5)
                 .RepeatForever()
                ).Build();
           scheduler.ScheduleJob(job,trigger);
           scheduler.Start();
       }
    }
