    Console.Write("Enter a Number\n");
    string input = Console.ReadLine(); //get the input
    int num = -1;
    if (!Int.TryParse(input, out num))
    {
        Console.WriteLine("Not an integer");
    }
    else
    {
       ...
    }
