    class SomeClass
    {
        private static string staticFoo;
    
        public string Foo
        {
            get { return SomeClass.staticFoo; }
        }
    }
