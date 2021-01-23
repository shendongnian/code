    int age = 0;
	var result = Int32.TryParse(Console.ReadLine(), out age);
	if (!result)
	{
		Console.WriteLine("Wrong age!");
        return;
	}
    if (age >= 35)
    {
         Console.WriteLine("You are getting old");
    }
    else if (age <= 35)
    {
        Console.WriteLine("You are still young");
    }
    else
    {
         Console.WriteLine("Thats not an option!");
    }
