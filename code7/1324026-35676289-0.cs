    using System;
    using System.Collections.Generic;
    using System.Reflection;
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass m = new MyClass();
                MethodInfo method = m.GetType().GetMethod("MyMethod");
                var result = (IEnumerable<string>)method.Invoke(m, null);
                foreach (var item in result)
                    Console.WriteLine("Printing:" + (item ?? "null"));
            
                Console.ReadLine();
            }
        }
        public class MyClass
        {
            public IEnumerable<string> MyMethod()
            {
                Console.WriteLine("Returning null");
                yield return null;
                Console.WriteLine("Returning 111");
                yield return "111";
                Console.WriteLine("Returning 222");
                yield return "222";
                Console.WriteLine("Returning 333");
                yield return "333";
            }
        }
    }
