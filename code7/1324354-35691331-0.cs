    private readonly SemaphoreSlim _sem = new SemaphoreSlim(50);
    private async Task SendRequestAsync(Uri uri)
    {
      await _sem.WaitAsync();
      try
      {
        ...
      }
      finally
      {
        _sem.Release();
      }
    }
