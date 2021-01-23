    public abstract class SharedClass
    {
       abstract CallApi();
       abstract Save();
       public void MyTemplateMethod()
       {
         // shared steps...
         
         // Call abstract templated method
         this.CallApi();
         // more shared steps...
         // Call abstract templated method
         this.Save(); 
       }
    }
    public class ChildClass1 : SharedClass
    {
      public void CallApi()
      {
         // I use API #1
      }
      
      public void Save()
      {
        // I save by doing it way #1
      }
    }
    public class ChildClass2 : SharedClass
    {
      public void CallApi()
      {
         // I use API #2
      }
      
      public void Save()
      {
        // I save by doing it way #2
      }
    }
