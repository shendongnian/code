    class Program
    {
        static MyGlobals globVariable = new MyGlobals();
        
        static void Main(string[] args)
        {
            globVariable.GetParam();
            long n = globVariable.TotNum;
            Console.WriteLine("Fib ({0}) = {1}", n, Fibonacci(n));
            Console.ReadKey();
        }
        static long Fibonacci(long n)
        {
            if (n <= 1)
            {
                return 1;
            }
            if (globVariable.MyNumbers[n] != -1)
            {
                return globVariable.MyNumbers[n];
            }
            else
            {
                globVariable.MyNumbers[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            }
            return globVariable.MyNumbers[n];
        }
    }
