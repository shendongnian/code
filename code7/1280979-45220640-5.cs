    using System;
    
    namespace AsciiChart
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);
                for (int i = 0; i < 256; i++) {
                    Console.Write(i+"=> ["+(char)i +"]  \n");
                }
                Console.ReadKey();
            }
        }
    }
