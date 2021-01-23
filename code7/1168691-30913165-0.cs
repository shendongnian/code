    double Prompt(string message) {
        while (true) {
            Console.Write(message + " ");
            try {
                return Convert.ToDouble(Console.ReadLine());
            } catch (FormatException) {
                Console.Beep();
                Console.WriteLine();
                Console.WriteLine("You have entered an invalid number!");
                Console.WriteLine();
            }
        }
    }
