    public class MyServiceBase  {
    
       static MyServiceBase  _instance;
    
       public MyServiceBase () {
          if ( _instance == null ) {
             // do the initialization
             _instance = this; 
          }
       } 
    }
