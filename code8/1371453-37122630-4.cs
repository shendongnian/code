    Based on: .NET 4.5
    C# program that uses base constructor initializer
    using System;
    public class A // This is the base class.
    {
        public A(int value)
        {
	        // Executes some code in the constructor.
	        Console.WriteLine("Base constructor A()");
        }
    }
    public class B : A // This class derives from the previous class.
    {
        public B(int value)
	        : base(value)
        {
	        // The base constructor is called first.
	        // ... Then this code is executed.
	        Console.WriteLine("Derived constructor B()");
        }
    }
