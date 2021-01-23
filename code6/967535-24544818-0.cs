    var scheduler = StdSchedulerFactory.GetDefaultScheduler();
    JobKey jobKey1 = new JobKey("job1", "group1");
    JobKey jobKey2 = new JobKey("job2", "group2");
    
    var job1 = JobBuilder.Create<Test1>().WithIdentity(jobKey1).Build();
    var job2 = JobBuilder.Create<Test2>().WithIdentity(jobKey2).StoreDurably(true).Build();
    
    ITrigger trigger1 = TriggerBuilder.Create()
       .WithIdentity("trigger1", "group1")
       .StartNow()
       .Build();
    
    JobChainingJobListener chain = new JobChainingJobListener("testChain");
    chain.AddJobChainLink(jobKey1, jobKey2);
    scheduler.ListenerManager.AddJobListener(chain, GroupMatcher<JobKey>.AnyGroup());
    scheduler.ScheduleJob(job1, trigger1);
    scheduler.AddJob(job2, true);
        
    scheduler.Start();
