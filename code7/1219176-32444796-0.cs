    using System;
    using System.IO;
    using System.IO.Compression;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                string zipPath = @"c:\example\result.zip";
                string extractPath = @"c:\example\extract";
    
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }
    }
