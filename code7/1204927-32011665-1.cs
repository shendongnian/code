    public class RegistrationManager
    {
      public IEnumerable<object> RegisteredObjects
      {
        get
        {
          return _registeredObjects;
        }
      }
      private List<object> _registeredObjects;
    
      public bool TryRegisterObject(object o) 
      {
        // ...
        // Add or not to Registered
        // ...
      }
    } 
