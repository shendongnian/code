    int result = 0;
    while (true)
    {
        string line = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(line))
        {
            break;
        }
        result += line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .Sum();
    }
    Console.WriteLine(result);
