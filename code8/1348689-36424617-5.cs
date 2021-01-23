    class Program
    {
        static void Main(string[] args)
        {
            // You give operation arguments as an object. An anonymous
            // object can be enough!
            int result = (int)MathOps.SumAndDivide.ExecuteAndLog
            (
                new
                {
                    a = 100,
                    b = 200,
                    c = 300
                }
            );
            Console.Read();
        }
    }
