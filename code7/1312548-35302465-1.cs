    var jobDetailList = new List<JobDetail>();
    foreach (var task in TasksByGroupId)
    {
        jobDetailList.Add(new JobDetail()
        {
            //Generate a new job detail for this job
            JobId = job.Id,
            TimeCompleted = DateTime.Now,
            CompletedBy = "ocodyc",
            TaskId = task.Id,
            TaskIdOrder = task.TaskOrder
        });
    }
    //TODO: Return a list of the task + notes
    db.Jobs.AddRange(jobDetailList);
    db.SaveChanges();
    return CreatedAtRoute("PostJobRoute", new { id = job.Id }, jobDetailList.AsEnumerable());
