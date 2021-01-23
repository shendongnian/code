    do
    {
        Console.WriteLine("How old are you?");
    }
    while (!int.TryParse(Console.ReadLine(), out age));
    agedetermine();
