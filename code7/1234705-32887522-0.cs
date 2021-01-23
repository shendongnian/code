    public class Parent
    {
      public event EventHandler ParentWentOut;
      public void GoToWork()
      {
         GoToWorkOverride();
         ParentWentOut();
      }
      
      protected virtual void GoToWorkOverride()
      {}
    }
    public class Mother : Parent
    {
       protected override void GoToWorkOverride()
       {
           // Do some stuff here
       }
    }
