    struct A : IHasAB
    {
        public A(int a, int b)
        {
            A = a;
            B = b;
        }
 
        public int A { get; }
        public int B { get; }
        // Note: mutable structs are a bad idea! That's why we implement
        // `A` and `B` as read-only properties.
    }
    struct B : IHasAB { … }  // same as for `A`
