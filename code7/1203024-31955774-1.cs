    int value = 601511616;
    List<int> digits = new List<int>();
    while (value > 0) 
    {
        digits.Add(value % 10);
        value /= 10;
    }
    digits.Reverse(); // Values has been inserted from least significant to the most
    Console.WriteLine("Count of digits: {0}", digits.Count);
    for (int i = 0; i < digits.Count; i++)
    {
        Console.Write("{0}", digits[i]);
        if (i % 2 == 0) Console.Write(","); // Insert comma after every 3 digits
    }
