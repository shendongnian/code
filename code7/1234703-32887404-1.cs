    public class Parent
    {
       public event EventHandler ParentWentOut;
       public void GoToWork()
       {
         ParentWentOut();
         SpecificMethodForChild();         
       }
       protected virtual void SpecificMethodForChild()
       {
          // Dont do anything, you can even make it abstract if it suits you
       }
    }
   
    public class Mother : Parent
    {
       protected override void SpecificMethodForChild()
       {
          // Do some stuff here
       }
    }
