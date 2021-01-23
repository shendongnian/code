    Task<double> TestTask = Task.Factory.StartNew<double>(() =>
            {
                System.Threading.Thread.Sleep(10000);
                return 0.5;
            });
            TestTask.ContinueWith(x =>
            {
                 result = x.Result;
                //do my stuff when its done
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
