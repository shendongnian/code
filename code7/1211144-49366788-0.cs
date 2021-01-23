    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace LogFileDeleter
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectoryInfo dir = new DirectoryInfo("c:\\inetpub\\logs\\logfiles\\w3svc1");
                DateTime testDate = DateTime.Now.AddDays(-5);
                foreach (FileInfo f in dir.GetFiles())
                {
                    DateTime fileAge = f.LastWriteTime;
                    if (fileAge < testDate) {
                        Console.WriteLine("File " + f.Name + " is older than today, deleted...");
                        File.Delete(f.FullName);
                    }
                    //Console.ReadLine(); //Pause -- only needed in testing.
                }
            }
        }
    }
