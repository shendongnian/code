    internal class TaskCancellationProblem
    {
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
    
        public TaskCancellationProblem()
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
        }
    
        public void RunFirstTask()
        {
            Task.Factory.StartNew( () => {
                    while (!token.IsCancellationRequested)
                    {
                        Console.WriteLine("Doing first task");
                        Thread.Sleep(1000);
                    }
                }, token);
        }
    
        public void CancelFirstAndRunSecond()
        {
            // Cancel the task that was running
            tokenSource.Cancel();
            Task.Factory.StartNew( () => {
                    while (true)
                    {
                        Console.WriteLine("Doing second task");
                        Thread.Sleep(1000);
                    }
                });
        }
    }
