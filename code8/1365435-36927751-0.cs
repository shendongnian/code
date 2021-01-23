             Task[] tasks = new Task[2];
             tasks[0] = Task.Run(() => 
             {
             SomeClass Object1  = new SomeClass();
                if (tasks[1].IsCompleted)
                {
                    tokenSource.Cancel();
                }
             });
             tasks[1] = Task.Run(() =>
             {
                 Application.EnableVisualStyles();
                 Application.SetCompatibleTextRenderingDefault(false);
                 Application.Run(new Form1());
             });
            
            Task.WaitAll(tasks[1]);
