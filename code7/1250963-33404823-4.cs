    using MoreLinq; // Install via NuGet
    foreach (byte[] line in buffer.Batch(16))
    {
        foreach (byte i in line)
            Console.WriteLine("{0:X2} ", i);
        Console.WriteLine();
    }
