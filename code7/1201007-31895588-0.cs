    var job = JobBuilder.Create<HelloJob>().WithIdentity(new JobKey("Task_1", "TaskGroup")).Build();
    var t = TriggerBuilder.Create()
            .WithIdentity("Trigger_1", "TaskGroup")
            .StartAt(DateBuilder.TodayAt(21, 15, 0))
            .EndAt(DateBuilder.TodayAt(21, 18, 0))
            .Build();
    _scheduleService.Scheduler.ScheduleJob(job, t);
