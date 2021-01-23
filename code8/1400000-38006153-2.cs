    class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(Arrow(3, 3));
                Console.WriteLine(Arrow(4, 4, 1));
                Console.WriteLine(Arrow(3, 4, 1));
                Console.ReadKey();
            }
    
            private static BigInteger Arrow(BigInteger baseNumber, BigInteger arrows)
            {
                return Arrow(baseNumber, baseNumber, arrows-1);
            }
    
            private static int Arrow(BigInteger baseNumber, BigInteger currentPower, BigInteger arrows)
            {
                Console.WriteLine("{0}^{1}", baseNumber, currentPower);
                var result = Power(baseNumber, currentPower);
    
                if (arrows == 1)
                {
                    return result;
                }
                else
                {
                    return Arrow(baseNumber, result, arrows - 1);
                }
            }
    
            private static BigInteger Power(BigInteger number, BigInteger power)
            {
                int x = number;
                for (int i = 0; i < (power - 1); i++)
                {
                    x *= number;
                }
                return x;
            }
        }
