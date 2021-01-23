            bool taskFinishedFlag = false;
            var t1 = Task.Factory.StartNew(() => { Thread.Sleep(4000); return 1; });
            var t2 = Task.Factory.StartNew(() => { Thread.Sleep(2000); 
                                                    throw new Exception("");return 1; });
            var t3 = Task.Factory.StartNew(() => { Thread.Sleep(4000); return 1; });
            Task<int>[] Tasks = new[] { t1, t2, t3 };
            for (int i = 0; i < Tasks.Length; i++)
            {
                Tasks[i].ContinueWith((t) =>
                    {
                        if (taskFinishedFlag) return;
                        taskFinishedFlag = true;
                        Console.WriteLine(t.Result);
                    }, TaskContinuationOptions.NotOnFaulted);
            }      
