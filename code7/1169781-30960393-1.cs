    private readonly object _mutex = new object();
    private Task<MyCollection<T>> _collectionTask;
    private Task<MyCollection<T>> LoadCollectionAsync(bool sync)
    {
      lock (_mutex)
      {
        if (_collectionTask == null)
          _collectionTask = DoLoadCollectionAsync(sync);
        return _collectionTask;
      }
    }
    private async Task<MyCollection<T>> DoLoadCollectionAsync(bool sync)
    {
      if (sync)
        return LoadCollectionSynchronously();
      else
        return await LoadCollectionAsynchronously();
    }
