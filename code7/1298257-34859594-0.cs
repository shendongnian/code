    public StatusCompleted(SPWebApplication webApplication, string TargetSite)
            : base(jobName, webApplication, null,SPJobLockType.Job)
    {
        Title = "Completed Projects Job";
        Properties.Add("TargetSite", TargetSite);
    }
