    class Outer
    {
        private void foo() {}
        class Nested
        {
            private readonly Outer _outer;
            public Nested(Outer outer)
            {
                _outer = outer;
            }
            public void bar()
            {
                _outer.foo(); // now we can call methods from "outer" class
            }
        }
    }
