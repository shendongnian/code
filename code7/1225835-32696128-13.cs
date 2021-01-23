    private static JobKey FindJobKey(IScheduler sched, ILogger logger, string jobGroupName)
    {
        JobKey returnJobKey = null;
    
        IList<string> jobGroupNames = sched.GetJobGroupNames();
    
        if (null != jobGroupNames)
        {
            string matchingJobGroupName = jobGroupNames.Where(s => s.Equals(jobGroupName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
    
            if (null != matchingJobGroupName)
            {
                GroupMatcher<JobKey> groupMatcher = GroupMatcher<JobKey>.GroupEquals(matchingJobGroupName);
                Quartz.Collection.ISet<JobKey> keys = sched.GetJobKeys(groupMatcher);
    
                if (null != keys)
                {
                    if (keys.Count > 0)
                    {
                        throw new ArgumentOutOfRangeException(string.Format("More than one JobKey Found. (JobGroupName='{0}')", jobGroupName));
                    }
                    returnJobKey = keys.FirstOrDefault();
    
                    if (null != returnJobKey)
                    {
                        throw new ArgumentOutOfRangeException(string.Format("No JobKey Found. (JobGroupName='{0}')", jobGroupName));
                    }
                }
            }
    
        }
    
        Thread.Sleep(TimeSpan.FromSeconds(1));
        return returnJobKey;
    }
