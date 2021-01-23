    using System;
    using System.Globalization;
    
    namespace StringReverser
    {
        class ReverseString
        {
            static string Reverse(string input)
            {
                char[] toReverse = input.ToCharArray();
                Array.Reverse(toReverse);
                return new string(toReverse);
            }
            static void Main(string[] args)
            {
                Console.Write("Enter string to reverse: ");
                string input = Console.ReadLine();
                Console.WriteLine(Reverse(input));
            }
        }
    }
