    public class Singleton {
    
       static Singleton _instance;
    
       public Singleton() {
          if ( _instance == null ) {
             // do the initialization
             _instance = this; 
          }
       } 
    }
