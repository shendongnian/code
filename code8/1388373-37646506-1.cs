    using System;
    using System.IO;
    
    class DriveInfoExample
    {
        public static void Main()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
    
            foreach (DriveInfo d in drives)
            {
                Console.WriteLine(d.Name);
                Console.WriteLine(d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine(d.VolumeLabel);
                    Console.WriteLine(d.DriveFormat);
                    Console.WriteLine(d.AvailableFreeSpace);
                    Console.WriteLine(d.TotalFreeSpace);
                    Console.WriteLine(d.TotalSize);
                }
            }
            Console.ReadLine();
        }
    }
