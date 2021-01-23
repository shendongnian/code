    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string quot = "\"";
                string compound = "Now I can use " + quot + "quotation marks" + quot + " around a variable";
                Console.WriteLine(compound);
            }
        }
    }
