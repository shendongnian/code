    int k = 0;
    string input = Console.ReadLine();
    if(Int32.TryParse(input, out k))
        Console.WriteLine("You have typed a valid integer: " + k);
    else
        Console.WriteLine("This: " + input + " is not a valid integer");
