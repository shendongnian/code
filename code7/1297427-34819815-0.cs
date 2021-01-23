    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Applicaton;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program2 p= new Program2();
                Console.WriteLine("hello world" + p.x);
                Console.ReadLine();
            }
        }
    }
    
    namespace Applicaton
    {
    
        public class Program2
        {
            public int x;
            public int Test()
            {
                x = 5;
                return x;
            }
        }
    }
