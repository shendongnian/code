    using System;
    using System.IO;
    using System.IO.Compression;
    namespace ConsoleApplication {
      class Program {
        static void Main(string[] args) {
          string startPath = @"c:\example\start";
          string zipPath = @"c:\example\result.zip";
          string extractPath = @"c:\example\extract";
          'Creates Zip File to directory as specified (startPath). And puts it in a specifed folder (zipPath)
                ZipFile.CreateFromDirectory(startPath, zipPath);
                  '
          Extracts Zip File to directory as specified(extractpath)
          ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
      }
    }
