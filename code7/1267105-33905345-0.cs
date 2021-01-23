    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int i = ThrowInTernaryOperator(1, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static int ThrowInTernaryOperator(int value, int max)
        {
            return value > max ? value / 0 : 0;
        }
    }
