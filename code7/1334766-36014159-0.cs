    public void Dispose()
    {
         Dispose(true);
         GC.SupressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
         if(!disposed)
         {
              if(disposing)
                   component.Dispose();
    
              disposed = true;
         }
    }
    
    ~DataContext() { Dispose(false); }
