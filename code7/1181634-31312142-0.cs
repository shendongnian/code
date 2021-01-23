    using System;
    
    class Parent
    {
        public void Foo(int x)
        {
            Console.WriteLine("Parent.Foo(int x)");
        }   
    }
        
    class Child : Parent
    {
        public void Foo(double y)
        {
            Console.WriteLine("Child.Foo(double y)");
        }
    }
        
        
    class Test
    {
        static void Main()
        {
            Child c = new Child();
            c.Foo(10);
        }
    }
