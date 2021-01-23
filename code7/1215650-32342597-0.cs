     public abstract class Parent<TChild> where TChild : Parent<TChild>
     {
         public string GetMyType()
         { 
             return ((TChild)this).GetTypeString();
         }
     }
