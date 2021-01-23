    private readonly ConcurrentDictionary<Guid, AsyncLazy<List<Data>>> CachedDataObjects;
    public Task<List<Data>> GetData(Guid ID)
    {
      var lazy = CachedDataObjects.GetOrAdd(ID, id =>
          new AsyncLazy<List<Data>>(() => Task.Run(() =>
          {
            try
            {
              return Service.GetKPI(ID);
            }
            catch (Exception e)
            {
              //deal with errors
              throw;
            }
          }, AsyncLazyFlags.RetryOnFailure | AsyncLazyFlags.ExecuteOnCallingThread)));
      return lazy.Task;
    }
