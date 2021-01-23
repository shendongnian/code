    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    namespace ConsoleApplication56
    {
        class Program
        {
            static void Main(string[] args)
            {
                FileInfo fi = new FileInfo(@"Your file path here");
                Console.WriteLine(fi.CreationTime);
                Console.ReadLine();
            }
        }
    }
