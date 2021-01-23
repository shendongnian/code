    class Program
    {
        static void Main(string[] args)
        {
            double FahrenheitInput = 0;
            double CelsiusInput = 0;
            double KilogramInput = 0;
            double PoundsInput = 0;
            int UserChoice = 0;
            do
            {
                Console.WriteLine("What would you like to convert? Enter the corresponding number.\n1. Fahrenheit to Celsius");
                Console.WriteLine("2. Celsius to Fahrenheit\n3. Pounds to Kilograms\n4. Kilograms to pounds\n5. Exit program");
                UserChoice = int.Parse(Console.ReadLine());
                switch (UserChoice)
                {
                    case 1:
                        Console.WriteLine("Enter the temperature in Fahreinheit, number only:");
                        while (!double.TryParse(Console.ReadLine(), out FahrenheitInput))
                        {
                            Console.WriteLine("Invalid format, please input again!");
                        };
                        Console.Clear();
                        Console.WriteLine(FahrenheitInput + " degrees fahrenheit in Celsius is " + Program.FahrenheitToCelsius(FahrenheitInput) + "\n\n");
                        break;
                    case 2:
                        Console.WriteLine("Enter the temperature in Celsius, number only:");
                        while (!double.TryParse(Console.ReadLine(), out CelsiusInput))
                        {
                            Console.WriteLine("Invalid format, please input again!");
                        };
                        Console.Clear();
                        Console.WriteLine(CelsiusInput + " degrees Celius in fahrenheit is " + Program.CelsiusToFahrenheit(CelsiusInput) + "\n\n");
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("This is not a valid entry. Please enter 1, 2, 3, 4, or 5.");
                        break;
                }
            } while (UserChoice != 5);
        }
        public static double FahrenheitToCelsius(double INPUT)
        {
            return (INPUT - 32) * 5 / 9;
        }
        public static double CelsiusToFahrenheit(double INPUT)
        {
            return INPUT * 1.8 + 32;
        }
    }
