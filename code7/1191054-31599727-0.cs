    public Task<byte[]> GetData(CancellationToken token)
    {
          cancellationToken.ThrowIfCancellationRequested;
          var tcs = new TaskCompletionSource<byte[]>();
          DataEventHandler dataHandler = null;
          dataHandler = (o, e) => 
          {
                 tcs.SetResult(e.Data);
          }
          StopEventHandler stopHandler = null;
          stopHandler = (os, se) =>
          {
                // Assuming stop handler has some sort of error property.
                tcs.SetException(se.Exception);
          }
          
          device.DataAvailable += dataHandler;
          device.ReceivingStoppedOrErrorOccured += stopHandler;
          device.Start();
          return tcs.Task;
    }
