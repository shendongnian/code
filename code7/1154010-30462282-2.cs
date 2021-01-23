    public async Task StartTimer(CancellationToken cancellationToken)
    {
    
       await Task.Run(async () =>
       {
          while (true)
          {
              DoSomething();
              await Task.Delay(10000, cancellationToken);
              if (ct.IsCancellationRequested)
                  break;
          }
       });
    
    }
