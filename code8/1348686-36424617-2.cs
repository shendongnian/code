    class Program
    {
        static void Main(string[] args)
        {
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
