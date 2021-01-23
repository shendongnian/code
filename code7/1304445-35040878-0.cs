    public abstract class A_Foo : I_Foo
    {
        public A_Foo() { }
        void I_Foo.Bar()
        {
            Bar(); // Just delegate to the abstract method
        }
        internal abstract void Bar();
    }
