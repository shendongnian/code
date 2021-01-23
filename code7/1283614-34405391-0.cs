    Worker worker = new Worker()
    {
        WorkerId = 1,
        Name = "Worker 1",
    };
    context.Workers.AddOrUpdate(w => w.Name, worker);
    context.SaveChanges();
    Job job = new Job()
    {
        JobId = 1,
        Name = "Job 1",                     
        Worker = worker.WorkerId
    };
    context.Jobs.AddOrUpdate(j => j.Name, job);
    context.SaveChanges(); //WorkerId is null for some reason
    MonitoringTask monitoringTask = new MonitoringTask
    {
        MonitoringTaskId = 1,
        Job = job.JobId,
        Name = "Task 1"                     
    };
    context.MonitoringTasks.AddOrUpdate(mt => mt.Name, monitoringTask);
    context.SaveChanges();
