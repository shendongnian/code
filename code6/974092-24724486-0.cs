    class MySingleton {
     //You can use any lazy initialization logic you like
     //I just used a static initializer as an example
     public static readonly MySingleton Instance = new ...();
    
     //Move all static data into this class
     //WCF never has to instantiate this class
     //Use it from anywhere you like
    }
    
    class MyWcfService {
     //This WCF service has no state
     //Therefore it does not need single instance mode
     //Any instancing mode will do
     //No one except WCF will ever need to use this class
     public void SomeServiceMethod() {
      MySingleton.Instance.DoSomething();
     }
    }
