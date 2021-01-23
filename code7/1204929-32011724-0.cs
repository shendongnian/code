    public class RegistrationManager
    {
      // change RegisteredObjects to be private
      private List<object> RegisteredObjects = new List<object>();
    
      // let RegisteredObjects be visible as read-only
      public IReadOnlyList<object> Items { 
        get {
          return RegisteredObjects;
        }
      }
    
      // your TryRegisterObject
      public bool TryRegisterObject(object o) 
      {
        // ...
        // Add or not to Registered
        // ...
      }
    } 
