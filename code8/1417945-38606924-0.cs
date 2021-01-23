        public class StopConcurrentTask : JobFilterAttribute, IElectStateFilter, IServerFilter
        {
            // All failed after retry will be catched here and I don't know if you still need this
            // but it is up to you
            public void OnStateElection(ElectStateContext context)
            {
                var failedState = context.CandidateState as FailedState;
                if (failedState != null && failedState.Exception != null)
                {
                    if (!string.IsNullOrEmpty(failedState.Exception.Message) && failedState.Exception.Message.Contains("Timeout expired. The timeout elapsed prior to obtaining a distributed lock on"))
                    {
                    }
                }
            }
            public void OnPerformed(PerformedContext filterContext)
            {
                // Do your exception handling or validation here
                if (filterContext.Exception == null) return;
                using (var connection = _jobStorage.GetConnection())
                {
                    var storageConnection = connection as JobStorageConnection;
                    if (storageConnection == null)
                        return;
                    var jobId = filterContext.BackgroundJob.Id
                    // var job = storageConnection.GetJobData(jobId); -- If you want job detail
                    var failedState = new FailedState(filterContext.Exception)
                    {
                        Reason = "Your Exception Message or filterContext.Exception.Message"
                    };
                    using (var transaction = connection.GetConnection().CreateWriteTransaction())
                    {
                        transaction.RemoveFromSet("retries", jobId);  // Remove from retry state
                        transaction.RemoveFromSet("schedule", jobId); // Remove from schedule state
                        transaction.SetJobState(jobId, failedState);  // update status with failed state
                        transaction.Commit();
                    }
                }
            }
        }
        public void OnPerforming(PerformingContext filterContext)
        {
            // Do nothing
        }
