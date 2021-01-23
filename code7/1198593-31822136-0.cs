    using System;
    using System.IO;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var reader = new StreamReader(@"C:\MyOriginalFile.txt"))
                using (var writer = new StreamWriter(@"C:\MyNewFile.txt", append: false))
                {
                    writer.Write(reader.ReadToEnd());
                }
                Console.Read();
            }
        }
    }
