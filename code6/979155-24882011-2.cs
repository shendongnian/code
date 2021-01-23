    using System;
    using System.Text;
    using System.IO;
    
    namespace FileReadTest
    {
        class Program
        {
            private static void Main(string[] args)
            {
                string fileName = "d:\\utf.txt";
    
                Console.WriteLine("Reding using File.Open");
                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    int oneByte = stream.ReadByte();
                    while (oneByte != -1)
                    {
                        Console.WriteLine(oneByte);
                        oneByte = stream.ReadByte();
                    }
                };
    
                Console.WriteLine("Reading using StreamReader");
                using (
                    StreamReader sourceStream =
                        new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite),
                            Encoding.Default))
                {
                    int oneChar = sourceStream.Read();
                    while (oneChar != -1)
                    {
                        Console.WriteLine(oneChar);
                        oneChar = sourceStream.Read();
                    }
                }
            }
        }
    }
