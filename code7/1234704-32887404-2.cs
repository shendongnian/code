    public class Parent
    {
       public event EventHandler ParentWentOut;
       public void GoToWork()
       {
         BeforeParentWentOut();
         ParentWentOut();
         AfterParentWentOut();         
       }
       protected virtual void BeforeParentWentOut()
       {
          // Dont do anything, you can even make it abstract if it suits you
       }
       protected virtual void AfterParentWentOut()
       {
          // Dont do anything, you can even make it abstract if it suits you
       }
    }
   
    public class Mother : Parent
    {
       protected override void BeforeParentWentOut()
       {
          // Do some stuff here
       }
    }
