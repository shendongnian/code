     public void Start(Action action)
        {
            Token = CancellationToken.None;
            IsRunning = true;
           Task.Factory.StartNew(() => Do(action), TaskCreationOptions.LongRunning);
        }
        async Task Do(Action action)
        {
            while (IsRunning)
            {
                action();
                await Task.Delay(Interval, Token);
              
            }
        }
