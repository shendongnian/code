    using System;
    using System.IO;
    namespace SampleFileOpener
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach (var arg in args)
                {
                    Console.WriteLine(arg);
                    if (File.Exists(arg))
                    {
                        Console.WriteLine(); //Empty line
                        var content = File.ReadAllText(arg);
                        Console.WriteLine(content);
                        Console.WriteLine(); //Empty line
                    }
                }
                Console.ReadLine();
            }
        }
    }
