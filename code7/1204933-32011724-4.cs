    public class RegistrationManager
    {
      // change RegisteredObjects to be private
      //TODO: do you really want List<object> instead of, say, List<RegisteredItem>?
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
