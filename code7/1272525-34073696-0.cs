    public async Task DoMyThing(CancellationToken token = default(CancellationToken))
    {
         while(!token.IsCancellationRequested)
         {
             this.DoMyMethod();
             try
             {
                 await Task.Delay(TimeSpan.FromMinutes(1), token);
             }
             catch(TaskCanceledException)
             {
                 break;
             }
         }
    }
