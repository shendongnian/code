    using System;
    using System.Linq;
    
    class MyClass
    {
        static void Main(string[] args) {
            string str = Console.ReadLine();
            
            string backwardsGuy = new string(str.Reverse().ToArray());
            if(str==backwardsGuy)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
