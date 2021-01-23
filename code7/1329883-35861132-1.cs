    class SimpleMath
    {
        private int number1;
        private int number2;
        public int Add()
        {
            int result = number1 + number2;
            return result;
        }
        public int Subtract()
        {
            int result = number1 - number2;
            return result;
        }
        public int SelectNumbers()
        {
            number1 = int.Parse(Console.ReadLine());
            number2 = int.Parse(Console.ReadLine());
        }
        static void Main()
        {
            SimpleMath operation = new SimpleMath();
    
            Console.WriteLine("Give me two numbers and I will add them");
            operation.NumSelect();
            int result = operation.Add();
            Console.WriteLine(
                "{0} + {1} = {2}",
                operation.number1,
                operation.number2,
                result);   
        }
    }
