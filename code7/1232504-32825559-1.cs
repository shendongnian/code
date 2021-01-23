    using System.Numerics;
    namespace ConsoleFiddle
    {
      class Program
      {
        static void Main(string[] args)
        {
            BigInteger from = 10;
            BigInteger to = 160000000;
            Console.WriteLine(SumSquares(from, to));
            Console.WriteLine(SumSquares2(from, to));
            Console.ReadKey();
        }
        static BigInteger SumSquares(BigInteger m, BigInteger n)
        {
            checked
            {
                BigInteger x = m - 1;
                BigInteger y = n;
                return (((y * (y + 1) * (2 * y + 1)) - (x * (x + 1) * (2 * x + 1))) / 6);
            }
        }
        static BigInteger SumSquares2(BigInteger m, BigInteger n)
        {
          checked
          {
            BigInteger sum = 0;
            for (BigInteger i = m; i <= n; ++i)
            {
                sum += i * i;
            }
            return sum;
          }
        }
