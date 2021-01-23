    static void Main(string[] args)
    {
        char arithmeticOperator;
        bool decision = false;
        while (decision == false)
        {
            Console.Write("Choose an Operator (+ - * /) : ");
            char.TryParse(Console.ReadLine(), out arithmeticOperator);
            switch (arithmeticOperator)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                    decision = true;
                    break;
                case '\0':
                    Console.WriteLine("Error!!! Value is a string.");
                    decision = false;
                    break;
                default:
                    decision = false;
                    break;
            }
            if (decision == false)
            {
                Console.WriteLine("Not an Operator, try again...");
            }
        }
    }
