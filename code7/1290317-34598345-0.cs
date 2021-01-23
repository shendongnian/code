       ...
          private readonly semaphore = new SemaphoreSlim(1,1);
       ...
          // total time allowed here is 100ms
          var tokenSource = new CancellationTokenSource(100); 
          try{
            await WorkMethod(parameters, tokenSource.Token); // work 
          } catch (OperationCancelledException ocx){
            // gracefully handle cancellations:
            label.Text = "Operation timed out";
          }
       ...  
        
        public async Task WorkMethod(object prm, CancellationToken ct){
          try{
            await sem.WaitAsync(ct); // equivalent to lock(object){...}
            // synchronized work, 
            // call  tokenSource.Token.ThrowIfCancellationRequested() or
            // check tokenSource.IsCancellationRequested in long-running blocks
            // and pass ct to other tasks, such as async HTTP or stream operations
          } finally {
            sem.Release();
          }
        }
