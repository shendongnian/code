    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Application;
        
    namespace ConsoleApplication1
    {
        class Program
            {
                static void Main(string[] args)
                {
                    Program2 program = new Program2();
                    //Below I am calling the Test() method knowing that Test() will return a value to save from having to initialize another variable.
                    Console.WriteLine("hello world" + program.Test());
                }
            }
        }
        namespace Applicaton
        {
        
            class Program2
            {
                public int Test()
                {
                    int x = 5;
                    return x;
                }
            }
        }
