    public class Outer
    {
        public Inner GetInstanceOfInner(string s)
        {
            var innerInstance = 
                typeof(Inner).GetConstructor(
                     System.Reflection.BindingFlags.NonPublic,  //Search for private/protected
                     null,   //Use the default binder
                     new[] { typeof(string) },  //Parameter types in the ctor
                     null)   //Default binder ignores this parameter
                     .Invoke(new[] { s }) as Inner; //Create and cast
            return innerInstance;
        }
        
        public class Inner
        {
            public Inner() { }
            private Inner(string s) { }
        }
    }
