    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace FizzBuzz
    {
    class Program
    {
        static void Main(string[] args)
        {
            int smallerNumber = 0;
            int biggerNumber = 0;
            bool running = true;
            while (running)
            {
                Console.Write("Starting number?     ->    "); 
                smallerNumber = int.Parse(Console.ReadLine());
                Console.Write("Ending number?       ->    ");
                biggerNumber = int.Parse(Console.ReadLine());
                if (smallerNumber >= biggerNumber)
                {
           Console.WriteLine("Starting number has to be smaller than the ending number!");
                }
                else
                {
                    running = false;
                }
            }
            var number = new Queue<int>();
            number.Enqueue(9999);
            int fizzorbuzz = number.Dequeue();
            for (int i = smallerNumber; i < biggerNumber; i++)
            {
                number.Enqueue(i);
            }
            foreach (int i in number)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FIZZBUZZZ");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz!");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz!");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
    }
