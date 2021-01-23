    using System;
    
    namespace TestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                string outputFormat = "out/pdf";
                var outputFormatEnum = outputFormat.ConverToEnum();
                var outputFormatEnumValueString = outputFormatEnum.ConvertToString();
    
                Console.WriteLine($"outputFormat: {outputFormat} | outputFormatEnumValueString: {outputFormatEnumValueString}");
    
                Console.ReadLine();
            }
        }
    }
