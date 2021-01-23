    using (var reader = new StreamReader(filename))
    {
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            Console.WriteLine(line);
        }
    }
