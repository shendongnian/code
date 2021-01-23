    abstract class LifeCycleBase
    {
      public void OnCreated(...)
      {
            .....
      }
      public void OnModified(...);
      {
            .....
      }
      ...
    }
    
    class LifeCycleLoger : LifeCycleBase
    {
      public void OnCreated(...)
      {
         ....
         base.OnCreate();
      }
    ....
    }
