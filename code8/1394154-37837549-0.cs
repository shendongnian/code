    internal class Derived1 : Base
    {
      public override async Task<bool> RunAsync(bool sync)
      {
        IsRunning = true;
        try
        {
          if (sync)
            return DoSomething();
          return await Task.Run(() => DoSomething());
        }
        finally
        {
          IsRunning = false;
        }
      }
    }
