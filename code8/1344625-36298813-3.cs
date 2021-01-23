    public class SiteBackgroundCaller : IRegisteredObject, IDisposable
        {
            private BlockingCollection<string> requestList;
            private CancellationTokenSource queueWorkerCts;
            private Task queueWorkerThread;
            public SiteBackgroundCaller()
            {
                // Register an instance of this class with the hosting environment, so we can terminate the task gracefully.
                HostingEnvironment.RegisterObject(this);
                requestList = new BlockingCollection<string>();
                queueWorkerCts = new CancellationTokenSource();
                queueWorkerThread = new Task(queueWorkerMethod, TaskCreationOptions.LongRunning);
                queueWorkerThread.Start();
            }
            public void QueueBackgroundRequest(string uri)
            {
                requestList.Add(uri);
            }
            private void queueWorkerMethod()
            {
                while (!queueWorkerCts.IsCancellationRequested)
                {
                    try
                    {
                        // This line will block until there is something in the collection
                        string uri = requestList.Take(queueWorkerCts.Token);
                        if (queueWorkerCts.IsCancellationRequested)
                            return;
                        // Make the request
                        HttpWebRequest r = (HttpWebRequest)HttpWebRequest.Create(uri);
                        HttpWebResponse response = (HttpWebResponse)r.GetResponse();
                    }
                    catch (OperationCanceledException)
                    {
                        // This may throw if the cancellation token is Cancelled.
                    }
                    catch (WebException)
                    {
                        // Something wrong with the web request (eg timeout)
                    }
                }
            }
            // Implement IRegisteredObject
            public void Stop(bool immediate)
            {
                queueWorkerCts.Cancel();
                queueWorkerThread.Wait();
            }
            // Implement IDisposable
            public void Dispose()
            {
                HostingEnvironment.UnregisterObject(this);
            }
        }
