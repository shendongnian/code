    using System;
    namespace Demo
    {
        public sealed class A
        {
            public Func<string> GetMsg { get; set; } = () => "Default";
            public void Print()
            {
                Console.WriteLine(GetMsg());
            }
        }
        public static class Program
        {
            public static void Main()
            {
                var a = new A(){ GetMsg = () => "Hello" };
                a.Print();
            }
        }
    }
