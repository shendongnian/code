                var retryStrategy = new Incremental(15, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
                var retryPolicy = new      RetryPolicy(DatabaseDeadlockTransientErrorDetectionStrategy.Instance, retryStrategy);
                // Receive notifications about retries.
                retryPolicy.Retrying += (sender, args) =>
                {
                    // Log details of the retry.
                    var msg = String.Format("SendGridController Retry - Count:{0}, Delay:{1}, Exception:{2}",
                        args.CurrentRetryCount, args.Delay, args.LastException);
                    Utils.Log4NetSimple(msg);
                };
                try
                {
                    // Do some work that may result in a transient fault.
                    int cnt1 = cnt;
                    await retryPolicy.ExecuteAsync(
                        async () =>
                        {
                            await InsertIntoSqlAsync(eventName, email, category, url, generalType, reason, 
                                statusString,  attempt, responseString, emailDetailsGuid, cnt1);
                        });
                }
                catch (Exception)
                {
                    Utils.Log4NetSimple("SendGridController:POST Retries all failed");
                }
