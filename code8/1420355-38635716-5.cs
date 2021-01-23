    struct A : IHasAB
    {
        public A(int a, int b)
        {
            A = a;
            B = b;
        }
 
        public int A { get; }  // Note: `A` and `B` are now properties, not fields
        public int B { get; }  // like before; interfaces do not allow you to declare fields.
        // Note also: mutable structs are a bad idea! That's why we implement
        // `A` and `B` as read-only properties.
    }
    struct B : IHasAB { … }  // same as for `A`
