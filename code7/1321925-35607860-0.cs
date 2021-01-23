    int sec = 0;
    Console.WriteLine("Enter number of seconds:");
    // Check if user input correct integer
    while(!int.TryParse(Console.ReadLine(),out sec))
    {
        Console.WriteLine("Your data is invalid. Please input again!");
    }
    TimeSpan t = TimeSpan.FromSeconds(sec);
    Console.WriteLine("Your result is " + t.ToString(@"hh\:mm\:ss"));
