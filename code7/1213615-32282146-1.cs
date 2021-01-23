    Console.WriteLine("Input length");
    int length;
    if (!int.TryParse(Console.ReadLine(), out length))
    {
        Console.WriteLine("Invalid number");
    }
    else
    {
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = i + 1;
        }
        Console.WriteLine("Array is");
        foreach (var i in array)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("Reverse Array is");
        foreach (var i in array.Reverse())
        {
            Console.WriteLine(i);
        }
    }
