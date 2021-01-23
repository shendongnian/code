    string[] values = packet.Split("47");
    for(int i = 0; i < values.Length; i++)
    {
        Console.WriteLine("[{0}] 47 {1}", i, values[i]);
        // C# 6+ way: Console.WriteLine($"[{i}] 47 {values[i]}");
    }
