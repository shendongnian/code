                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                Task<bool>[] tasks = new Task<bool>[3];
                tasks[0] = Task.Factory.StartNew<bool>(() => Find(1, 2));
                tasks[1] = Task.Factory.StartNew<bool>(() => Find(4, 7));
                tasks[2] = Task.Factory.StartNew<bool>(() => Find(13, 14));
                
                tasks[0].ContinueWith(_ =>
                {
                    if (tasks[0].Result)
                        tcs.TrySetResult(tasks[0].Result);
                });
    
                tasks[1].ContinueWith(_ =>
                {
                    if (tasks[1].Result)
                        tcs.TrySetResult(tasks[1].Result);
                });
    
                tasks[2].ContinueWith(_ =>
                {
                    if (tasks[2].Result)
                        tcs.TrySetResult(tasks[2].Result);
                });
    
                Task.WaitAny(tasks);
    
                Console.WriteLine("Found");
                ContinueWork();
