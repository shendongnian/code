    string age = Console.ReadLine();
    try
    {
        int ageInInt = Convert.ToInt16(age);
        if (ageInInt >= 35)
        {
            Console.WriteLine("You are getting old");
        }
    }
    catch
    {
        Console.WriteLine("Please type a real number");
    }
