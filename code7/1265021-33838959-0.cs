    public static async Task LogExceptions(this Task task)
    {
      try
      {
        await task.ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        LogException(ex);
      }
    }
