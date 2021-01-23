     public virtual Data GetData(Credential credential)
     {
         Task<Data> inProgressDataTask = Task.Factory.StartNew(() => GetDataInternal(credential));
    
         try
         {
             return inProgressDataTask.Result;
         }
         catch (AggregateException ex)
         {
             _logger.ErrorException(ex, "An error occurs during getting full data");
             throw ex.InnerException;
         }
     }
