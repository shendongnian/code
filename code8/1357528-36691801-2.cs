	class Program
    {
        static void Main(string[] args)
        {
            FibonacciInput input = new FibonacciInput();
            input.GetParam();
            long n = input.TotNum;
            Console.WriteLine("Fib ({0}) = {1}", n, Fibonacci(n, input.MyNumbers));
            Console.ReadKey();
        }
	}
