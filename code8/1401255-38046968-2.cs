    class Program
    {
        static void Main(string[] args)
        {
            int number1, number2;
            if (int.TryParse(Console.ReadLine(), out number1) && int.TryParse(Console.ReadLine(), out number2))
            {
                Console.WriteLine("the sum of numbers are :{0}", DoStuff(number1, number2));
            }
            else
                Console.ReadKey();
        }
        public static int DoStuff(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }
    
    }
