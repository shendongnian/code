    public sealed class Singleton
    {
       private static volatile Singleton instance;
       private static object syncRoot = new Object();
       
       public ObservableCollection<MyData> list {get; private set;}
    
       private Singleton() {
           list = new ObservableCollection<MyData>();
       }
    
       public static Singleton Instance
       {
          get 
          {
             if (instance == null) 
             {
                lock (syncRoot) 
                {
                   if (instance == null)
                   {
                      instance = new Singleton();
                   }
                }
             }
    
             return instance;
          }
       }
    }
