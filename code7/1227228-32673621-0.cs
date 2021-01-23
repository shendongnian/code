    public static void Main(string[] data)
    {
        if(data.Length == 0)
        {
            Console.WriteLine("No input :(");
        }
        double result;
            
        if(!Double.TryParse(data[0], out result))
        {
            Console.WriteLine("Invalid input: " + data[0]);
            return;
        }
        Console.WriteLine("Starting with number: " + result);
        char op;
        double number;
        string errorMessage;
        do
        {
            if(!TryGetData(out op, out number, out errorMessage))
            {
                Console.WriteLine("Invalid input: " + errorMessage);
                continue;
            }
            switch (op)
            {
                case '+':
                    result += number;
                    break;
                case '-':
                    result -= number;
                    break;
                case '*':
                    result *= number;
                    break;
                case '/':
                    result /= number;
                    break;
                default:
                    Console.WriteLine("Invalid operator: " + op);
                    continue;
            }
            Console.WriteLine("Result = " + result.ToString());
        } while (Char.ToLower(op) != 'q');
    }
    static bool TryGetData(out char anOperator, out double aNumber, out string message)
    {
        aNumber = 0;
        message = null;
        Console.Write("Enter an operator and a number or 'q' to quit: ");
        var line = Console.ReadLine();
        anOperator = line[0];
        if (anOperator != 'q' && anOperator != 'Q')
        {
            if(line.Length <= 2)
            {
                // string too short
                message = "Input string too short";
                return false;
            }
            var isValidNumber = Double.TryParse(line.Substring(2), out aNumber);
            if(!isValidNumber)
            {
                message = "Invalid number: " + line.Substring(2);
                return false;
            }
            if(isValidNumber && (anOperator == '/' && aNumber == 0))
            {
                message = "Cannot divide by 0.";
                return false;
            }
        }
        return true;
    }
