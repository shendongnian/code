    public class NullFooDummyFactory: IDummyFactory
    {
        public bool CanCreate(Type type)
        {
            return typeof(Foo).IsAssignableFrom(type);
        }
    
        public object Create(Type type)
        {
            return null;
        }
    
        public Priority Priority
        {
            get { return Priority.Default; }
        }
    }
