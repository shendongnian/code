    using System;
    class A
    {
        public void Foo(A a)
        {
            Console.WriteLine("A.Foo");
        }
    }
    class B : A
    {
        //overloading
        public void Foo(B b)
        {
            Console.WriteLine("Overload");
        }
        //hiding
        public new void Foo(A a)
        {
            Console.WriteLine("Hide");
        }
    }
    class Test
    {
        static void Main()
        {
            A a = new A(); 
            A b = new B();
            B c = new B();
            a.Foo(a);   //A.foo
            b.Foo(a);   //A.foo
            b.Foo(b);   //A.foo
            ((dynamic) b).Foo(a); //hide (equivalent to overriding Foo in B when A.Foo is virtual or abstract)
            c.Foo(a);   //hide
            c.Foo(b);   //hide
            c.Foo(c);   //overload
        }
    }
