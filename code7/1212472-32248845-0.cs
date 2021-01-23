    public class SomeScope : INameScope
    {
        void INameScope.Register(string name, object scopedElement)
        {
            RegisterName(name, scopedElement);
        }
        public void Register(...)
        {
            // Does something different
        }
        public void RegisterName(...)
        {
            // ...
        }
        ...
    }
