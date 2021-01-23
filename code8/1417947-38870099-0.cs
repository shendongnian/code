    public class StopWakeUpExecution : JobFilterAttribute, IServerFilter
    {
        public void OnPerformed(PerformedContext filterContext)
        {
            
        }
        public void OnPerforming(PerformingContext filterContext)
        {
            using (var connection = JobStorage.Current.GetConnection())
            {
                var recurring = connection.GetRecurringJobs().FirstOrDefault(p => p.Job.ToString() == filterContext.BackgroundJob.Job.ToString());
                TimeSpan difference = DateTime.UtcNow.Subtract(recurring.LastExecution.Value);
                if (recurring != null && difference.Seconds < 15)
                {
                    // Execution was due in the past. We don't want to automaticly execute jobs after server crash though.
                    var storageConnection = connection as JobStorageConnection;
                    if (storageConnection == null)
                        return;
                    var jobId = filterContext.BackgroundJob.Id;
                    var deletedState = new DeletedState()
                    {
                        Reason = "Task was due in the past. Please Execute manually if required."
                    };
                    using (var transaction = connection.CreateWriteTransaction())
                    {
                        transaction.RemoveFromSet("retries", jobId);  // Remove from retry state
                        transaction.RemoveFromSet("schedule", jobId); // Remove from schedule state
                        transaction.SetJobState(jobId, deletedState);  // update status with failed state
                        transaction.Commit();
                    }
                }
            }
        }
    }
