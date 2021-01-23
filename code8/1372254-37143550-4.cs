    double GetInput(string prompt)
    {
        Console.WriteLine(prompt);
        double userInput;
        while(!(double.TryParse(Console.ReadLine(), out userInput) && userInput > 0))
        {
            Console.WriteLine("Please enter a positive number.");
        }
        return userInput;
    }
