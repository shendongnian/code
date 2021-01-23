    while (true)
    {
        var line = savednames.ReadLine();
        if (string.IsNullOrWhiteSpace(line))
        {
            Console.WriteLine("No more content!");
            break;
        }
    }
