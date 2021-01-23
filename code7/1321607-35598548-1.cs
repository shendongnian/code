    int input1 = 0;
    Console.WriteLine("Enter First Digit");
    if (!int.TryParse(Console.ReadLine(), out input1))
    {
        Console.WriteLine("Your first data is not an interger");
        Console.ReadLine();
        return;
    }
    int input2 = 0;
    Console.WriteLine("Enter Second Digit");
    if (!int.TryParse(Console.ReadLine(), out input2))
    {
        Console.WriteLine("Your second data is not an interger");
        Console.ReadLine();
        return;
    }
    Console.WriteLine("Total = " + (input1 + input2));
    Console.ReadLine();
