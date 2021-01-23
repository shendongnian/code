    Console.WriteLine("Enter First Digit");
    int input1 = 0;
    if (int.TryParse(Console.ReadLine(), out input1))
    {
        Console.WriteLine("Enter Second Digit");
        int input2 = 0;
        if (int.TryParse(Console.ReadLine(), out input2))
        {
            Console.WriteLine("Total = " + (input1 + input2));
            Console.ReadLine();
        }
        else Console.WriteLine("Your data is not a interger");
    }
    else Console.WriteLine("Your data is not a interger");
