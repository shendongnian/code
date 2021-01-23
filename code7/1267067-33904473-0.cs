    namespace CalculatorTest
    {
    class Calculator
    {
        public static string WriteText (string input)
        {
            return "" + input;
        }
        public static string WriteNumber(int sumOfNumbers)
        {
            return "" + sumOfNumbers;                 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s = Calculator.WriteText("Hello World!");
            Console.WriteLine(s);
            string n = Calculator.WriteNumber(53 + 28);
            Console.WriteLine(n);
            Console.Read();
        }
    }
}
