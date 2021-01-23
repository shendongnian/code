    public class AsyncCommand: MvxCommand, IAsyncCommand
    {
      private readonly Func<Task> _execute;
      public AsyncCommand(Func<Task> execute)
          : this(execute, null)
      {
      }
      public AsyncCommand(Func<Task> execute, Func<bool> canExecute)
          : base(async () => await execute(), canExecute)
      {
        _execute = execute;
      }
      public Task ExecuteAsync()
      {
        _execute();
      }
    }
