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
                    // The only two properties that can be accessed for all drives
                    // whether they are online or not (ready)
                    //
                    Console.WriteLine(d.Name);
                    Console.WriteLine(d.DriveType);
                }
                Console.ReadLine();
            }
        }
    }
