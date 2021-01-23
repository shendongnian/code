    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication85
    {
        class Program
        {
            static string[] fileNames = { "file1", "file2", "file3", "file4", "file5" };
            static void Main(string[] args)
            {
                List<string> strings = new List<string>();
                foreach (string fileName in fileNames)
                {
                    strings.AddRange(File.ReadAllLines);
                }
                File.WriteAllLines("file6", strings.Distinct);
            }
        }
     
    }
