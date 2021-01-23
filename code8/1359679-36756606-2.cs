    class MyService
    {
        private bool async;
        private string name;
        private CancellationTokenSource tokenSource;
        private bool isRunning = false;
        private Task myTask = null;
        public MyService(string name, bool async)
        {
            this.name = name;
            this.async = async;
        }
        public string Name { get { return name; } }
        public bool IsRunning { get { return isRunning; } }
        public async Task Run()
        {
            isRunning = true;
            tokenSource = new CancellationTokenSource();
            myTask = Task.Run(() => Do_CPU_Intensive_Job(tokenSource.Token), tokenSource.Token);
            if (!async)
                await myTask;
        }
        public async Task Stop()
        {
            tokenSource.Cancel();
            if (myTask != null)
                await myTask;
            isRunning = false;
        }
        private void Do_CPU_Intensive_Job(CancellationToken token)
        {
            Console.WriteLine("doing some heavy job for Task " + name);
            int i = 0;
            while (!token.IsCancellationRequested)
            {
                Console.WriteLine("Task: " + name + " - " + i);
                Thread.Sleep(1000);
                i++;
            }
            Console.WriteLine("Task " + name + " not yet completed! I need to do some cleanups");
            Thread.Sleep(1000);
            Console.WriteLine("Task " + name + " - CPU intensive and cleanups done!");
        }
    }
