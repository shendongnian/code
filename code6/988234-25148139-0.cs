    public class MyProxySingleton
    {
    
    private static Service1Client  _proxy = null;
    
    public static Service1Client Instance 
    { 
      get
      {
        if (_proxy == null)
        {
            _proxy = new Service1Client();
        }
       
        return _proxy;
      }
    }
    }
 
