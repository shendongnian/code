    Console.WriteLine("Enter a digit between 10 and 50 ");
    xx = Console.ReadLine();
    
    do
    {
        x = int.Parse(xx);
        if (x <= 10 || x >= 50)
            Console.WriteLine("Pleae input again: ");
    }
    while (x <= 10 || x >= 50);
    Console.WriteLine("The number is in between!");
    Console.Read();
