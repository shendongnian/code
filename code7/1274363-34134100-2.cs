    public virtual async Task<Data> GetData()
    {
         try
         {
             return await GetInternalData();
         }
         catch (AggregateException ex)
         {
             _logger.ErrorException(ex, "An error occurs during getting full data");
             throw ex.InnerException;
         }
     }
