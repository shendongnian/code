       CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken token = cts.Token;
                Task myTask = Task.Factory.StartNew(() =>
               {
                   for (int i = 0; i < 2000; i++)
                   {
                       token.ThrowIfCancellationRequested();
    
                       // Body of for loop.
                   }
               }, token);
    
                //Do sometohing else 
                //if cancel needed
                cts.Cancel();
