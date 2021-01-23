    internal class TaskCancellationProblem
    {
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
    
        public TaskCancellationProblem()
        {
            ResetSourceAndToken();
        }
    
        private void ResetSourceAndToken()
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
        }
    
        public void RunFirstTask()
        {
            // check if cancellation has been requested previously and reset as required
            if (tokenSource.IsCancellationRequested)
                ResetSourceAndToken();
    
            Task.Factory.StartNew(() =>
            {
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
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine("Doing second task");
                    Thread.Sleep(1000);
                }
            });
        }
    }
