    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Original Objects from your source code
                var myKeyValuePair = new KeyValuePair<string, string>("HELLO", "THERE");
                var notKeyValuePar = "HELLO THERE";
                // This is so we don't know what it is.
                object o1 = myKeyValuePair;
                object o2 = notKeyValuePar;
                // TEST with a KeyValuePair
                if (IsKeyValuePair(o1))
                    Console.WriteLine("o1 is KeyValuePair");
                else
                    Console.WriteLine("o1 is NOT KeyValuePair");
                // TEST with a string
                if (IsKeyValuePair(o2))
                    Console.WriteLine("o2 is KeyValuePair");
                else
                    Console.WriteLine("o2 is NOT KeyValuePair");
                Console.ReadLine();
            }
            static private bool IsKeyValuePair(Object o)
            {
                return String.Compare(o.GetType().Name.ToString(), "KeyValuePair`2") == 0;
            }
        }
    }
