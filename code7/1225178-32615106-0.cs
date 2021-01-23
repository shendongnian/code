    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var scanPath = @"c:\your\path";
                var scanPattern = "*.log";
                var outfile = "result.log";
                var logs = from file in Directory.EnumerateFiles(scanPath, scanPattern)
                           from line in file.AsLines()
                           where line.Substring(20, 11) == "140.25.1.37"
                           select line;
                logs.WriteAsLinesTo(outfile);
            }
        }
        public static class Tools
        {
            public static void WriteAsLinesTo(this IEnumerable<string> lines, string filename)
            {
                using (var writer = new StreamWriter(filename))
                    foreach (var line in lines)
                        writer.WriteLine(line);
            }
            public static IEnumerable<string> AsLines(this string filename)
            {
                using (var reader = new StreamReader(filename))
                    while (!reader.EndOfStream)
                        yield return reader.ReadLine();
            }
        }
    }
