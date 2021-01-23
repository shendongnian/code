    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Folders folders = new Folders(@"c:\temp", null);
                Console.ReadLine();
            }
        }
        public class Folders
        {
            public string path { get; set; }
            List<string> files = new List<string>();
            List<Folders> folders = new List<Folders>();
            Folders parent = null;
            public Folders(string path, Folders parent)
            {
                this.parent = parent;
                this.path = path;
                foreach (string folderPath in Directory.GetDirectories(path))
                {
                    Folders newFolder = new Folders(folderPath, this);
                    folders.Add(newFolder);
                }
                files = Directory.GetFiles(path).ToList();
                int pathlength = path.Length;
                Boolean first = true;
                Console.Write(path);
                if (files.Count == 0) Console.WriteLine();
                foreach (string file in files)
                {
                    string shortname = file.Substring(file.LastIndexOf("\\") + 1);
                    if (first)
                    {
                        Console.WriteLine("\\" + shortname);
                        first = false;
                    }
                    else
                    {
                        
                        Console.WriteLine(new string(' ', pathlength + 1) + shortname);
                    }
                }
                
            }
        }
    }
    ​
