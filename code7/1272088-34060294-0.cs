    class Test
    {
        public Test() // <-- this one does compile since it is the constructor
        {
            myProp = 1;
        }
        public void SomeMethod() // <-- this one doesn't compile
        {
            myProp = 1;
        }
        public int myProp { get; } // CS0840
        // to create a read-only property
        // try the following line instead
        public int myProp2 { get; private set; }
    }
