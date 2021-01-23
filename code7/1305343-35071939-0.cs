    public class SomeClass
    {
      private readonly Dispatcher _dispatcher;
    
      public SomeClass()
      {
        _dispatcher = Dispatcher.CurrentDispatcher;
      }
    
      public void SomeOperation()
      {
        InvokeIfNeeded(() => Console.WriteLine("Something"));
      }
    
      private void InvokeIfNeeded(Action action)
      {
        if (_dispatcher.Thread != Thread.CurrentThread)
          _dispatcher.Invoke(action);
        else
          action();
      }
    }
