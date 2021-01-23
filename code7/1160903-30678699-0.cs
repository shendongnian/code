    // An instance of this is passed into the concrete view.
    public interface IViewImplementation
    {
      void DoSomething();
      // Or the async equivalent:
      //   Task DoSomethingAsync();
    }
