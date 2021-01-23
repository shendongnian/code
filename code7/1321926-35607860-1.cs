    Console.WriteLine("Enter number of seconds:");
    double sec = 0;
    // Check if user input correct integer
    while(!double.TryParse(Console.ReadLine(),out sec))
    {
        Console.WriteLine("Your data is invalid. Please input again:");
    }
    TimeSpan t = TimeSpan.FromSeconds(sec);
    Console.WriteLine("Your result is " + t.ToString(@"hh\:mm\:ss"));
    Console.ReadLine();
