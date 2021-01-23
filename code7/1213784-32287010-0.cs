    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "C 6 C 9 C 10 C 11 C 12";
                string[] array = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < 10; i += 2)
                {
                    string suit = array[i];
                    string rank = array[i + 1];
                    Console.WriteLine("Card {0} , Suit : {1}, Rank : {2}" , i/2, suit, rank);
                }
                Console.ReadLine();
            }
        }
    }
    ​
