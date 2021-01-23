    public static class Calc
    {
        public static double Plus(double a, double b)
        {
            return a+b;
        }
        public static double Minus(double a, double b)
        {
            return a-b;
        }
    }
    public void Main()
    {
        Console.WriteLine("\na+b:");
        Console.WriteLine(Calc.Plus(1,1));
        Console.WriteLine("\na-b:");
        Console.WriteLine(Calc.Minus(1,1));
    }
