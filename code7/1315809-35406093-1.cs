    namespace Demo
    {
        abstract class Base // Abstract means derived classes must implement.
        {
            public abstract void SomeVirtualMethod();
        }
        class Derived1 : Base
        {
            public override void SomeVirtualMethod()
            {
                // Do something.
            }
        }
        class Derived2 : Base
        {
            public override void SomeVirtualMethod()
            {
                // Do something.
            }
        }
        class Program
        {
            static void Main()
            {
                int i = 0;
                Base b;
                if (i == 0)
                    b = new Derived1();
                else
                    b = new Derived2();
                b.SomeVirtualMethod();
            }
        }
    }
