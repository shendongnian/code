    public class MyClass : IEquatable<MyClass>
    {
        public bool Equals(MyClass c) { ... }
        public override bool Equals(object o)
        { 
            var c = o as MyClass;
            return c != null && Equals(c);
        }
    }
