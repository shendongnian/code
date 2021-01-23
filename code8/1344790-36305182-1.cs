    using System;
    using System.IO;
    using System.Threading.Tasks;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                string filename = @"Your test filename goes here";
                Parallel.ForEach(File.ReadLines(filename), process);
            }
            private static void process(string line)
            {
                Console.WriteLine(line);
            }
        }
    }
