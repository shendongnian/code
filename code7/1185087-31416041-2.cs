    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Test
    {
        class A
        {
            public virtual void show()
            {
                Console.WriteLine("Base Class!");
                Console.ReadLine();
            }
        }
    
        class B : A
        {
            public override void show()
            {
                Console.WriteLine("Derived Class!");
                Console.ReadLine();
            }
        }
    
        class Polymorphism
        {
            public static void Main()
            {          
                A a2 = new B();
                a2.show(); // calls derived class.
            }
        }
    }
