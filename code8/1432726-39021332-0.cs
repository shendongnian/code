    using System;
    using System.IO;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                if (di != null)
                {
                    FileInfo[] subFiles = di.GetFiles();
                    if (subFiles.Length > 0)
                    {
                        Console.WriteLine("Files:");
                        foreach (FileInfo subFile in subFiles)
                        {
                            Console.WriteLine("   " + subFile.Name + " (" + subFile.Length + " bytes) " + "Directory name: " 
                                + di.Name + " Directory full name: " + di.FullName);
                        }
                    }
                    Console.ReadKey();
                }
    
            }
        }
    }
