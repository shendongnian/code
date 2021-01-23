    using LibraryA;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Initializer.Init();
                RealClass c = new RealClass();
                Console.WriteLine("From LibraryA: " + c.DoIt());
                Console.ReadKey();
            }
        }
    }
