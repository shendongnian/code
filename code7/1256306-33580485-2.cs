    using System;
    class A
    {
        public A() { }
    }  
    class B
    {
        private int data;
        public B() { }
        public B(int x) { data = x; }
        public int Data { get { return data; } }
    }
    class Base<T1, T2> where T2 : new()
    {
        private T1 a;
        public void Method(object[] args)
        {
            //pass args to T2 constructor 
            T2 b = (T2)Activator.CreateInstance(typeof(T2), args);
        }
    }
    class Derived : Base<A,B>
    {
        public new void Method(object[] args)
        {
            base.Method(args); 
        }
    }
    class Test
    {
        static void Main()
        {
            Derived d = new Derived();
            d.Method(new object[]{ 1 });
        }
    }
