    static async Task<T> Do<T, U>(
                Func<Task<T>> action,
                TimeSpan retryInterval,
                int retryCount = 3) 
                  where U : Exception
    {
      var exceptions = new List<U>();
    
      for(int retry = 0; retry < retryCount; retry++)
      {
         try
         {
            return await action();
         }
         catch(U ex)
         {
            exceptions.Add(ex);
         }
         catch(Exception ex) { }
         await Task.Delay(retryInterval);
      }
      throw new AggregateException(exceptions);
    }
