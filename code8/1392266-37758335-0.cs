    using System;
    using static Globals.Commands;
    
    namespace MyConsole
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                WaitForReturn();
            }
        }
    }
    
    namespace Globals
    {
        public static class Commands
        {
            public static void WaitForReturn()
            {
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
        }
    }
