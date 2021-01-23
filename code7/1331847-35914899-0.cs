    public class Ops: Operations
    {
       private static Ops instance;
    
       private Ops() {}
    
       public static Ops Instance
       {
          get 
          {
             if (instance == null)
             {
                instance = new Ops();
             }
             return instance;
          }
       }
    
     public void Call()
     {
       // do something
     }
    }
