    using System;
    
    public class Singleton
    {
       public Dictionary<string,object> State {get; private set;}
       private static Singleton instance;
    
       private Singleton() {
            State = new Dictionary<string,object>();
       }
    
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
