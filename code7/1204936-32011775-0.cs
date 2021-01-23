    public class RegistrationManager
    {
       private List<object> _registeredObjects; 
       public IReadOnlyCollection<object> RegisteredObjects
       {
          get
          {
             return _registeredObjects as IReadOnlyCollection<object>;
          }
       } 
    }
