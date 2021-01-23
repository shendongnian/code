    using System;
    using System.IO;
    using System.Diagnostics;
    
    class Program {
        static void Main(string[] args) {
            string path = @"c:\temp\test.bin";
            var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);
            fs.Seek(1024L * 1024 * 1024, SeekOrigin.Begin);
            var buf = new byte[4096];
            var sw = Stopwatch.StartNew();
            fs.Write(buf, 0, buf.Length);
            sw.Stop();
            Console.WriteLine("Writing 4096 bytes took {0} milliseconds", sw.ElapsedMilliseconds);
            Console.ReadKey();
            fs.Close();
            File.Delete(path);
        }
    }
