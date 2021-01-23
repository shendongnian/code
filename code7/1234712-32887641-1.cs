    var T = Task.Factory.StartNew(() =>
            {
                JobWorker jobWorker = new JobWorker();
                jobWorker.Execute(jobTask);
            }).ContinueWith(tsk =>
            {
                var flattenedException = tsk.Exception.Flatten();
                Console.Log("Exception! " + flattenedException);
                return true;
             });
            },TaskContinuationOptions.OnlyOnFaulted);  //Only call if task is faulted
