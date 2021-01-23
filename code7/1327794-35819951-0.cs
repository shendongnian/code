    public Result Execute(Parameters parameters)
    {
      return ExecuteCoreAsync(parameters, sync: true).GetAwaiter().GetResult();
    }
    public Task<Result> ExecuteAsync(Parameters parameters)
    {
      return ExecuteCoreAsync(parameters, sync: false);
    }
    private async Task<Result> ExecuteCoreAsync(Parameters parameters, bool sync)
    {
      if (sync)
      {
        Thread.Sleep(2000); // sync implementation
        return new Result();
      }
      else
      {
        await Task.Delay(2000); // async implementation
        return new Result();
      }
    }
