    double GetInput(string prompt)
    {
        Console.WriteLine(prompt);
        double userInput;
        while(!double.TryParse(Console.ReadLine(), out userInput)
        {
            Console.WriteLine("Your input was not numeric. Please enter a number.");
        }
        return userInput;
    }
