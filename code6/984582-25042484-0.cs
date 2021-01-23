    using System;
    
    class Program {
        static void Main(string[] args) {
            var prg = new Program();
            Console.ReadLine();
        }
        ~Program() {
            Console.WriteLine("Clean-up completed");
            System.Threading.Thread.Sleep(1500);
        }
    }
