    static void Main(string[] args)
        {
            try
            {
                double quotient = DivideTwoNumbers(10, 0);
                AnotherFunction();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        static int DivideTwoNumbers(int dividend, int divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException();
            return dividend / divisor;
        }
 
