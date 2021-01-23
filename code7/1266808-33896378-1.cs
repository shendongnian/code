    object bytes = new byte[10];
    // No warning now
    if (bytes is sbyte[])
    {
        Console.WriteLine("Yes"); // This is reached
    }
