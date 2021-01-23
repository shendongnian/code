    using System;
    using System.Text;
    
    namespace With_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Console.WriteLine("This will output something: ");
                Console.ReadLine();
                some.Print();
                Console.ReadLine();
            }
        }
    }
    class some
    {
        public static void Print()
        {
            Console.WriteLine("something");
        }
    }
