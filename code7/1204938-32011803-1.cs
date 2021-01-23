    public class RegistrationManager
    {
      public RegistrationManager()
      {
          _registeredObjects=new List<object>();
          _readOnlyRegisteredObjects=new ReadOnlyCollection<object>(_registeredObjects);
      }
      public IEnumerable<object> RegisteredObjects
      {
        get
        {
          return _readOnlyRegisteredObjects;
        }
      }
      private List<object> _registeredObjects;
      ReadOnlyCollection<object> _readOnlyRegisteredObjects;
      public bool TryRegisterObject(object o) 
      {
        // ...
        // Add or not to Registered
        // ...
      }
    } 
