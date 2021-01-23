    public class Command
    {
      private readonly TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>();
      public Task<string> ExecuteAsync()
      {
        return _tcs.Task;
      }
      internal void ExecuteCommand()
      {
        if (_tcs.Task.IsCompleted) return;
        try
        {
          // Do your work...
          _tcs.SetResult(result);
        }
        catch (Exception ex) 
        {
          _tcs.SetException(ex);
        }
      }
    }
