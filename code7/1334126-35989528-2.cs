    class SomeClass
    {
        private static string staticFoo;
        
        private string instanceFoo;
        
        public SomeClass()
        {
            instanceFoo = staticFoo; // Assign the instance variable.
        }
        
        public static string StaticFoo // Static property.
        {
            get { return staticFoo; }
        }
        
        public string Foo // Instance property.
        {
            get { return instanceFoo; }
        }
    }
