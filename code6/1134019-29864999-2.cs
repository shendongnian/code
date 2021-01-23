    class MyJob : IDisposable 
    {
         private bool _disposed = false;
         protected virtual void Dispose(bool disposing)
         {
              if (!_disposed)
              {
                  //Dispose unmanaged resources and any child disposables here
              }
         }
    
         void Dispose()
         {
              this.Dispose(true);
              GC.SuppressFinalize(this);
         }
    
         ~MyJob()
         {
              //ONLY use if you have unmanaged resources that DO NOT
              //implement their own finalizers.
              Dispose();
         }
    }
