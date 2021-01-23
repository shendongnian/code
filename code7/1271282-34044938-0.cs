    static Func<Task> ErrorActionAsync
    {
      get
      {
        return async () =>
        {
          await Task.Yield();
          throw new NotImplementedException();
        };
      }
    }
    private static Action ErrorAction
    {
      get
      {
        return async () => { await ErrorActionAsync(); }
      }
    }
