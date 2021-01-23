    class MyService : StatefulService
    {
      public MyService (StatefulServiceContext context, IReliableStateManager stateManager)
          :base (context, stateManager)
      {
      }
    
      public void MyMethod()
      {
        // do stuff..
      }
    }
