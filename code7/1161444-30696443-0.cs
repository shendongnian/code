    using System;
    using System.Numerics;
    
    namespace PirateCoins
    {
        class Program
        {
            static void Main(string[] args)
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(GetTreasure(n));
            }
            static BigInteger GetTreasure(int n)
            {
                BigInteger result = BigInteger.Pow(n, n + 1) - (n - 1);
                return result;
            }
        }
    }
