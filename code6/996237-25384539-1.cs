    public void Dispose()
    {
       if(this.Status != Closed) // check if it is not already closed
         {
             SendCloseCommand();
         }
       ////other resources release
    }
