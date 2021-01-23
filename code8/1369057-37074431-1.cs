    using System;
    
    namespace TestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                string incoming = "out/pdf";
                var bar = incoming.ConverToEnum();
                var enumValueString = bar.ConvertToString();
    
                Console.WriteLine($"bar: {bar} | enumValueString: {enumValueString}");
    
                Console.ReadLine();
            }
        }
    }
