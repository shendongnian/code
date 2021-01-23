    public static void CreateScheduler(bool rerun, string jobName, string jobType, string schedule, string startTime)
    {
        var job =  (IJob) Activator.CreateInstance(Type.GetType("MyProject.Jobs." + jobType + "." + jobName + ", " + Assembly.GetExecutingAssembly().FullName.ToString()));
        var scheduler =
            new QuartzConstraints().ScheduleJob<IJob>(
                job // <-- add this
                jobName,
                jobType,
                jobName + "Trigger",
                jobType,
                rerun,
                schedule,
                startTime);
        scheduler.Start();
    }
