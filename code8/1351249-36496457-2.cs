    using System;
    using System.Linq;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(new[] { "a" }.Select(entity =>
                {
                    switch (entity)
                    {
                        case "a":
                            return "foo";
                        case "b":
                            return "bar";
                        default:
                            return "baz";
                    }
                }).First());
                Console.ReadKey();
            }
        }
    }
