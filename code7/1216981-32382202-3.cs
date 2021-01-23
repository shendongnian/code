    var solverRun = new SolverRun
    {
        Base = job.Base,
        Duration = context.JobRunTime,
        Result = (context.Result ?? "").ToString(),
        RunName = job.RunName,
        Start = context.FireTimeUtc.GetValueOrDefault().LocalDateTime,
        ApplicationUserId = OwnerId
    };
    dbContext.Set<SolverRun>().Add(solverRun);
    dbContext.SaveChanges();
