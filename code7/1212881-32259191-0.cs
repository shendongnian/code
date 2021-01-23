    using System;
    class A
    {
        public virtual void Test()
        {
	       Console.WriteLine("A.Test");
        }
    }
    class B : A
    {
        public override void Test()
        {
	      Console.WriteLine("B.Test");
        }
    }
    class Program
    {
         static void Main()
         {
	       // Compile-time type is A.
	       // Runtime type is A as well.
	       A ref1 = new A();
	       ref1.Test();
	       // Compile-time type is A.
	       // Runtime type is B.
	       A ref2 = new B();
	       ref2.Test();
         }
    }
