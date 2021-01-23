    public class MyClass
    {
        // Read-only access from outside, no 'set'
        public object RestrictedMember { get; private set; }
    }
