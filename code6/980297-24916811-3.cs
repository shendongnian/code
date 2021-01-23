    List<string> lines = new List<string>();
    using (var reader = new StreamReader(filename))
    {
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            lines.Add(line);
        }
    }
    foreach (var line in lines)
    {
        Console.WriteLine(line);
    }
