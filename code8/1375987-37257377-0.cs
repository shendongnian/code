    using System;
    
    namespace DemoConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                SameNamespace.PartialClass.MethodOne();
                SameNamespace.PartialClass.MethodTwo();
                DifferentNamespace.PartialClass.MethodThree();
            }
        }
    }
    
    namespace SameNamespace
    {
        public partial class PartialClass
        {
            public static void MethodOne()
            {
                Console.WriteLine("Method One.");
            }
        }
    
        public partial class PartialClass
        {
            public static void MethodTwo()
            {
                Console.WriteLine("Method Two.");
            }
        }
    }
    
    namespace DifferentNamespace
    {
        public partial class PartialClass
        {
            public static void MethodThree()
            {
                Console.WriteLine("Method Three.");
            }
        }
    }
