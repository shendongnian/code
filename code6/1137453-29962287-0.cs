    using System;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string allwords = "This is a test this is a test aaaaaaaaaaa this is a test ";
                bool c = allwords.Split().Any(s => s.Length > 10);
                if (c == false)
                {
                    Console.WriteLine(allwords);
                }
                else
                {
                    Console.WriteLine("Woahh there one of these words is more than 10 chars");
                }
            }
        }
    }
