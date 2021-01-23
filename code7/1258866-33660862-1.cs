    Food foodChoice;
    int n;
    string temp;
    while (!(Enum.TryParse<Food>(temp = Console.ReadLine(), true, out foodChoice)) || int.TryParse(temp,out n))
    {
        Console.WriteLine("Not a valid choice.");
    }
