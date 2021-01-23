    public sealed class A
    {
        public void Method() { }
    }
    public sealed class B
    {
        A a;
        public void Method()
        {
            // Do B stuff
            // Call fake "virtual" method
            a.Method();
        }
    }
