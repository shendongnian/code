    public class RegistrationManager
    {
       private List<object> _registeredObjects;
       public IReadOnlyList<object> RegisteredObjects
       {
           get{  return _registeredObjects; }
       }
       public bool TryRegisterObject(object o) 
       {
          // ...
          // Add or not to Registered
          // ...
       }
     } 
