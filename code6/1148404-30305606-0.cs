          /// <summary>
        /// Continuous loop that monitors the queue and launches jobs when they are retrieved.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public virtual async Task ProcessMessagesAsync(CancellationToken token)
        {
            CloudQueue queue = _queueClient.GetQueueReference(_queueName);
            await queue.CreateIfNotExistsAsync(token);
            var runningTasks = new ConcurrentDictionary<int, Task>();
            while (!token.IsCancellationRequested)
            {
                Debug.WriteLine("inLoop");
                // The default timeout is 90 seconds, so we won’t continuously poll the queue if there are no messages.
                // Pass in a cancellation token, because the operation can be long-running.
                CloudQueueMessage message = await queue.GetMessageAsync(token);
                if (message != null)
                {
                    var t = ProcessMessage(message, queue, token);
                    var c = t.ContinueWith(z => RemoveRunningTask(t.Id, runningTasks));
                    while (true)
                    {
                        if (runningTasks.TryAdd(t.Id, t))
                            break;
                        Task.Delay(25);
                    }                                    
                }                    
                else
                {
                    try
                    {
                        await Task.Delay(500, token);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
            while (!runningTasks.IsEmpty)
            {
                Debug.WriteLine("Waiting for running tasks");
                Task.Delay(500);
            }
        }
        private static void RemoveRunningTask(int id, ConcurrentDictionary<int, Task> runningTasks)
        {
            while (true)
            {
                Task outTask;
                if (runningTasks.TryRemove(id, out outTask))
                    break;
                Task.Delay(25);
            }
        }
