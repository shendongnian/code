    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        public class Program
        {
            static void Main()
            {
                var dict = new Dictionary<string, Action<string>>
                {
                    ["A"] = Console.WriteLine,
                    ["B"] = doSomething1,
                    ["C"] = doSomething2,
                    ["D"] = str => Console.WriteLine("Inline: " + str)
                };
                string s = "ABCD";
                string first = dict.Keys.FirstOrDefault(t => s.Contains(t));
                if (first != null)
                    dict[first](first);
            }
            private static void doSomething1(string x)
            {
                Console.WriteLine("doSomething1 with " + x);
            }
            private static void doSomething2(string x)
            {
                Console.WriteLine("doSomething2 with " + x);
            }
        }
    }
