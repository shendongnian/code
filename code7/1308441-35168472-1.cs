    int[] numbers = new int[5];
    int i = 0;
    while (i < 5)
    {
        Console.WriteLine("Enter a number: ");
        string c = Console.ReadLine();
        int value;
        if (!int.TryParse(c, out value)) continue;
        numbers[i] = value;
        i++;
    }
    foreach (int t in numbers)
        Console.Write(t + " ");
