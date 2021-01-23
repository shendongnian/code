    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnrar;
    using NUnrar.Archive;
    using System.IO;
    
    namespace NunrarSOF
    {
        class Program
        {
            static void Main(string[] args)
            {
                RarArchive archive = RarArchive.Open(@"C:\Work\fileName.rar");
                int count = 0;
                //archive.Volumes.ToString();
                foreach (RarArchiveEntry entry in archive.Entries)
                {
                    count++;
                    Console.WriteLine(entry.FilePath);
                }
                Console.WriteLine(count);
            }
        }
    }
