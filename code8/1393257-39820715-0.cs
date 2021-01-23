    private static bool IsOKToAddJob(string JobName, string QueueName, out string NotOKKey)
        {
            try
            {
                var monapi = JobStorage.Current.GetMonitoringApi();
                var processingJobs = monapi.ProcessingJobs(0, 1000);
                NotOKKey = processingJobs.Where(j => j.Value.Job.ToString() == JobName).FirstOrDefault().Key;
                if (!string.IsNullOrEmpty(NotOKKey)) return false;
                var scheduledJobs = monapi.ScheduledJobs(0, 1000);
                NotOKKey = scheduledJobs.Where(j => j.Value.Job.ToString() == JobName).FirstOrDefault().Key;
                if (!string.IsNullOrEmpty(NotOKKey)) return false;
                var enqueuedJobs = monapi.EnqueuedJobs(QueueName, 0, 1000);
                NotOKKey = enqueuedJobs.Where(j => j.Value.Job.ToString() == JobName).FirstOrDefault().Key;
                if (!string.IsNullOrEmpty(NotOKKey)) return false;
                NotOKKey = null;
                return true;
            }
            catch (Exception ex)
            {
                //LOG your Exception;
            }
        }
