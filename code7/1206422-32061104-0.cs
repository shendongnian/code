    using System;
    class Test
    {
        static void Main()
        {
            //split input by spaces into array
            string[] name = Console.ReadLine().Split(); 
            Console.WriteLine("First name: " + name[0]);
            Console.WriteLine("Last Name: " + name[1]);
        }
    }
