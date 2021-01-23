    foreach (var task in TasksByGroupId)
    {
        db.JobDetails.AddObject(new JobDetail()
            {
                TaskId = task.Id,
                TaskIdOrder = task.TaskOrder
            });
    }
    db.SaveChanges();
