    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Enumerable.Range(1, 70).ToList();
            Shuffle(numbers);
            foreach (int number in numbers.Take(50))
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }
        static void Shuffle<T>(IList<T> items)
        {
            Random rand = new Random();
            for (int i = items.Count - 1; i > 0 ; i--)
            {
                int j = rand.Next(i + 1); // Returns a non-negative random integer that is less than the specified maximum - MSDN
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }
    }
