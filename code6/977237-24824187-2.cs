        public static class Extensions
        {
            /// <summary>
            /// Returns a task that completes when all the passed tasks are completed
            /// </summary>        
            public static Task WhenAll(IEnumerable<Task> tasks)
            {
                var tcs = new TaskCompletionSource<object>();
    
                var remainingTasks = tasks.ToList();
                int count = remainingTasks.Count();
                var exceptions = new List<Exception>();
    
                foreach (var task in remainingTasks)
                {
                    task.ContinueWith(t =>
                    {
                        if (Interlocked.Decrement(ref count) == 0)
                        {
                            foreach (var task1 in remainingTasks)
                            {
                                if (task1.IsFaulted)
                                {
                                    exceptions.Add(task1.Exception);
                                }
                            }
    
                            if (exceptions.Any())
                            {
                                tcs.SetException(new AggregateException(exceptions));
                            }
                            else
                            {
                                tcs.SetResult(null);
                            }
                        }
                    });
                }
    
                return tcs.Task;
            }
    }
