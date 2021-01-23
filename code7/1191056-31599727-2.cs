    public Task<byte[]> GetData(CancellationToken token)
    {
          cancellationToken.ThrowIfCancellationRequested;
          var tcs = new TaskCompletionSource<byte[]>();
          DataEventHandler dataHandler = null;
          dataHandler = (o, e) => 
          {
              device.DataAvailable -= dataHandler;
              tcs.SetResult(e.Data);
          }
          StopEventHandler stopHandler = null;
          stopHandler = (os, se) =>
          {
                device.ReceivingStoppedOrErrorOccured -= stopHandler;
                // Assuming stop handler has some sort of error property.
                tcs.SetException(se.Exception);
          }
          
          device.DataAvailable += dataHandler;
          device.ReceivingStoppedOrErrorOccured += stopHandler;
          device.Start();
          return tcs.Task;
    }
