    struct Foo
    {
        public int ID { set; get; }
    
        public Foo Identity() { return this; }
    
        public static void Bar(Foo? foo)
        {
            int? foo1 = foo?.Identity().ID; // compile
            Foo foo2 = (foo?.Identity()).Value; // Compiles
        }
    }
