    using ExtensionMethods;
    using System;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("a".ConvertKey());
            }
        }
    }
    
    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static string ConvertKey(this String key)
            {
                switch (key)
                {
                    case "a":
                        return "foo";
                    case "b":
                        return "bar";
                    default:
                        return "baz";
                }
            }
        }
    }
