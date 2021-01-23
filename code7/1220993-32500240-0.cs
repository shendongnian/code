    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static string Zip(string text)
            {
                byte[] utf8bytes = System.Text.Encoding.UTF8.GetBytes(text);
                MemoryStream compressedStream = new MemoryStream();
                using (var gzipStream = new GZipStream(compressedStream, 
                    CompressionMode.Compress, true))
                {
                    gzipStream.Write(utf8bytes, 0, utf8bytes.Length);
                }
                compressedStream.Position = 0;
                byte[] deflated = new byte[compressedStream.Length];
                compressedStream.Read(deflated, 0, (int)compressedStream.Length);
                return Convert.ToBase64String(deflated);
            }
        
            static void Main(string[] args)
            {
                Console.WriteLine(Zip("fubar"));
                Console.ReadLine();
            }
        }
    }
