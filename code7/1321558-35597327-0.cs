    decimal capsCount = 0;
    foreach (char c in e.message)
    {
        if (Char.IsUpper(c))
            capsCount++;
    }
    
    Console.WriteLine($"{(capsCount/e.message.Replace(" ", string.Empty).Length).ToString("0.00%")} is caps.");
    Console.WriteLine($"{e.message.Replace(" ", string.Empty).Length}:{capsCount}");
