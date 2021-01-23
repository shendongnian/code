    public class Singleton
    {
       private static Singleton instance;
    
       private Singleton() {}
    
       public IList<object> PseudoGlobalObjects {get;set;}
    
       public static Singleton Instance
       {
          get 
          {
             if (instance == null)
             {
                instance = new Singleton();
             }
             return instance;
          }
       }
    }
