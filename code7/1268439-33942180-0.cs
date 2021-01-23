    public Task ExecuteAsync(Action action)
    {
      action();
      return Task.FromResult(0);
    }
