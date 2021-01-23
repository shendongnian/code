    using System;
    namespace Demo
    {
        public sealed class A
        {
            public Func<string> GetMsg { get; }
            public A(Func<string> getMsg)
            {
                GetMsg = getMsg;
            }
            public void Print()
            {
                Console.WriteLine(GetMsg());
            }
        }
        public static class Program
        {
            public static void Main()
            {
                var a = new A(() => "Hello");
                a.Print();
            }
        }
    }
