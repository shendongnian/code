    int total = 0;
    int count = 1;
    while (count <= 15)
    {
        Console.WriteLine("Enter credit #" + count.ToString() + ":");
        int input;
        if (int.TryParse(Console.ReadLine(), out input))
        {
            total += input;
            count += 1;
        }
    }
    Console.WriteLine(total);
