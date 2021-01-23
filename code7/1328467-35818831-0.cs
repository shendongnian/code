    using System;
    using System.Drawing;
    namespace ConsoleApplicationFont
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach (var item in FontFamily.Families)
                    Console.WriteLine(item.Name);
                Console.ReadLine();
            }
        }
    }
