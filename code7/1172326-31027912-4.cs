    while (name != "A" && surname != "A")
    {
        Console.WriteLine("Enter Name:");
        name = Console.ReadLine(); // Point A
        if (name != "A")
        {
            Console.WriteLine("Enter Surname:");
            surname = Console.ReadLine(); // Point B
        }
    }
