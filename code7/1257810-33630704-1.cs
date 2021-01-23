       public class Singleton
    {
       private static Singleton instance;
       public string[] MyArray { get; set; }
       //better using a List<string>
    
       private Singleton() {
          //instanciate MyArray here
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
