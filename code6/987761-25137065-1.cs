     using System;
    using Microsoft.VisualBasic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ar = new string[11];
                Console.WriteLine(ar.GetUpperBound(0));
                Console.WriteLine(ar.Length);
                Console.WriteLine(Microsoft.VisualBasic.Information.UBound(ar));
                Console.ReadKey();
            }
        }
    }
