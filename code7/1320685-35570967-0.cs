    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication11
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                long FreeSize = 0;
                DriveInfo[] drive = DriveInfo.GetDrives().Where(x =>
                {
                    if (x.RootDirectory.FullName != Path.GetPathRoot(Environment.SystemDirectory).ToString() && x.AvailableFreeSpace >= FreeSize)
                    {
                        FreeSize = x.AvailableFreeSpace; 
                        Console.WriteLine("{0}Size:{1}", x.Name, x.AvailableFreeSpace);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }).ToArray();
    
                Console.ReadLine();
    
            }
        }
    }
