    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Hangman {
        class Program {
            static void Main(string[] args) {
                string[] myWordArrays = File.ReadAllLines(@"C:\Users\YouTube Upload\Documents\Visual Studio 2013\Projects\Hangman");
                    
                Console.WriteLine(myWordArrays[2]);
                Console.ReadKey();
            }
        }
    }
