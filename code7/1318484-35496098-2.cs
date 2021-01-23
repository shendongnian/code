    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(10);
    private async Task<Response> ThrottledSendRequestAsync(HttpRequestMessage request, CancellationToken token)
    {
      await _semaphore.WaitAsync(token);
      return await SendRequestAsync(request, token);
    }
    private async Task PeriodicallyReleaseAsync(Task stop)
    {
      while (true)
      {
        var timer = Task.Delay(TimeSpan.FromSeconds(1.2));
        if (await Task.WhenAny(timer, stop) == stop)
          return;
        // Release the semaphore at most 10 times.
        for (int i = 0; i != 10; ++i)
        {
          try
          {
            _semaphore.Release();
          }
          catch (SemaphoreFullException)
          {
            break;
          }
        }
      }
    }
