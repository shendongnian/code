    public class DispatcherServiceStub : IMainThreadDispatcherService 
    {
      public bool RequestMainThreadAction(Action action)
      {
        action();
      }
    }
