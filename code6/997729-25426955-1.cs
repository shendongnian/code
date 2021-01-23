    private async Task RetryAsync(Func<Task> action, int retries = 30)
    {
      while (retries > 0)
      {
        try
        {
          await action();
          return;
        }
        catch (SqlException exception)
        {
          // exception is not a deadlock
          if (exception.Number != 1205)
            throw;
        }
        await Task.Delay(1000);
        retries--;
      }
      throw new Exception("Retry count exceeded");
    }
