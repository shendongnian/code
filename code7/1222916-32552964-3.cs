    static double answer(double a, double b, char simb)
    {
        switch (simb) {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
            case ':':
                return a / b;
            default:
                Console.WriteLine("Error");
                return 0;
        }
    }
