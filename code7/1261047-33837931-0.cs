    class MyService : StatefulService
    {
      public MyService (IReliableStateManager stateManager)
      {
         this.StateManager = stateManager;
      }
    
      public void MyMethod()
      {
        // do stuff..
      }
    }
