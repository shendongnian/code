    using System;
    using System.IO;
    
    namespace DriveInfoExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo d in drives)
                {
                    Console.WriteLine(d.Name);
                    Console.WriteLine(d.DriveType);
                    Console.ReadLine();
                }
            }
        }
    }
