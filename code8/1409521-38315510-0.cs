    StreamReader reader = process.StandardOutput;
    StringBuilder builder = new StringBuilder();
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        builder.AppendLine(line);
        Console.WriteLine(line);
    }
    string allLines = builder.ToString();
