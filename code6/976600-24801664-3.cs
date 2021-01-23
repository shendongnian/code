    // This is the variable, in which will be stored the temperature.
    double temperature;
    // Ask the  user input the temperature.
    Console.WriteLine("Please enter the temperature in Celsius: ");
    // If the given temperature hasn't the right format, 
    // ask the user to input it again.
    while(!Double.TryParse(Console.ReadLine(), out temperature))
    {
        Console.WriteLine("The temperature has not the right format, please enter again the temperature: ");
    }
