    using System;
    using System.Text;
    namespace BinaryCount
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Please enter a number and the computer will convert it into binary.");
                string NumberIn = Console.ReadLine();
                int Number = Int32.Parse(NumberIn);
                double loopCount = Math.Log(Number, 2); // Log2 of a number will tell you the highest order bit that's set
                StringBuilder s = new StringBuilder();
                for (int i = 0 ; i <  loopCount ; ++i)
                {
                    if (Number % 2 == 1)
                        s.Append("1");
                    else
                        s.Append("0");
                    Number = Number >> 1;
                }
                StringBuilder done = new StringBuilder();
                for (int i = s.Length - 1 ; i >= 0 ; i--)
                {
                    done.Append(s[i]);
                }
                Console.WriteLine(done);
                Console.ReadLine();
            }
        }
    }
