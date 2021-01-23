     async Task<string> Test()
            {
                try
                {
                    var v = await TaskCaller();
                    return v;
                }
                catch (Exception ee)
                {
                    throw ee;
                }
            }
    
            async Task<string> TestTask()
            {
                string ty = string.Empty;
                Task<Task> task = new Task<Task>(async () =>
                {
                    Thread.Sleep(2000);
                    ty = "TestTask";
                });
    
                task.Start();
                task.Result.Wait();
                return ty;
            }
    
            async Task<string> TaskCaller()
            {
                string ty = string.Empty;
                Task<Task> task = new Task<Task>(async () =>
                {
                    ty = await TestTask();
                });
                task.Start();
                task.Result.Wait();
                return ty;
            }
