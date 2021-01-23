    public void Dispose()
    {
         Dispose(true);
         GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
         if(!disposed)
         {
              if(disposing)
              {     
                  component.Dispose();
              }
              disposed = true;
         }
    }
    
    ~DataContext() { Dispose(false); }
