    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (StreamWriter writer = new StreamWriter("test.txt"))
                {
                    writer.Write("Line 1");
                    writer.WriteLine("Still line 1");
                    writer.WriteLine("Line 2");
                }
            }
        }
    }
