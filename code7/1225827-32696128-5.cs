    private static JobKey FindaJobKey(IScheduler sched, ILogger logger)
    {
        JobKey returnJobKey = null;
        IList<string> jobGroupNames = sched.GetJobGroupNames();
        if (null != jobGroupNames)
        {
            if (jobGroupNames.Count > 0)
            {
                GroupMatcher<JobKey> groupMatcher = GroupMatcher<JobKey>.GroupEquals(jobGroupNames.FirstOrDefault());
                Quartz.Collection.ISet<JobKey> keys = sched.GetJobKeys(groupMatcher);
                returnJobKey = keys.FirstOrDefault();
                if (null == returnJobKey)
                {
                    throw new ArgumentOutOfRangeException("No JobKey Found");
                }
            }
        }
        Thread.Sleep(TimeSpan.FromSeconds(1));
        return returnJobKey;
    }
