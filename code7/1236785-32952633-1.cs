    int[] array = new int[input];
    
    for (int i = 0; i < input; i++)
    {
        // No need for the counter variable at all
        Console.WriteLine("Please enter entry number " + (input + 1));
        int number = Convert.ToInt16(Console.ReadLine());
        array[i] = number;
    }
