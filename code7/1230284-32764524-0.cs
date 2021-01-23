    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string path = @"C:\temp\test.txt";
            static void Main(string[] args)
            {
                long offset = 25;
                long key = offset - (offset % 16);
                using (Stream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    BinaryReader brFile = new BinaryReader(fileStream);
                    fileStream.Position = key;
                    List<byte> offsetByte = brFile.ReadBytes(16).ToList();
                    string offsetString = string.Join(" ", offsetByte.Select(x => "0x" + x.ToString("x2")).ToArray());
                }
            }
        }
    }​
