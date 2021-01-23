	class Program
    {
        static void Main(string[] args)
        {
            FibonacciInput input = new FibonacciInput();
            FibonacciCalculator calculator = new FibonacciCalculator();
            input.GetParam();
            long n = input.TotNum;
            Console.WriteLine("Fib ({0}) = {1}", n, calculator.Fibonacci(n, input.MyNumbers));
            Console.ReadKey();
        }
	}
