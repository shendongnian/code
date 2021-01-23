    while (true)
    {
        var line = savednames.ReadLine();
        if (string.IsNullOrEmpty(line))
        {
            Console.WriteLine("No more content!");
            break;
        }
    }
