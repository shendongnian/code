    class Test
    {
        public Test() // <-- this one does compile since it is the constructor
        {
            MyProp = 1;
        }
        public void SomeMethod() // <-- this one doesn't compile
        {
            MyProp = 1;
        }
        public int MyProp { get; } // <-- no CS0840 any more!
    }
