    while (running)
    {
        line = streamReader.ReadLine();
        if (line != null)
        {
            Console.WriteLine(line);
        }
    }
