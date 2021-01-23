    public class RegistrationManager
    {
        public IReadOnlyCollection<object> RegisteredObjects
        {
            get { return new ReadOnlyCollection<object>(_registeredObjects); }
        }
        private List<object> _registeredObjects;
        public bool TryRegisterObject(object o)
        {
            // ...
            // Add or not to Registered
            // ...
        }
    }
