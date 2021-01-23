    public class ActionInvoker
    {
        private readonly Action _actionToInvoke;
        public ActionInvoker(Action actionToInvoke)
        {
            _actionToInvoke = actionToInvoke;
            _cancellationTokenSource = new CancellationTokenSource();
        }
        private readonly CancellationTokenSource _cancellationTokenSource;
        private Task _executer;
        public void Start(int min, int max, int minDuration)
        {
            if (_executer != null)
            {
                return;
            }
            _executer = Task.Factory.StartNew(
                        async () => await ExecuteRandomAsync(min, max, _actionToInvoke),
                        _cancellationTokenSource.Token, TaskCreationOptions.LongRunning, 
                        TaskScheduler.Default)
                        .Unwrap();
        }
        private void Stop()
        {
            try
            {
                _cancellationTokenSource.Cancel();
            }
            catch (OperationCanceledException e)
            {
                // Log the cancellation.
            }
        }
        private async Task ExecuteRandomAsync(int min, int max, Action action)
        {
            Random random = new Random();
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                await Task.Delay(random.Next(min, max), _cancellationTokenSource.Token);
                action();
            }
        }
    }
