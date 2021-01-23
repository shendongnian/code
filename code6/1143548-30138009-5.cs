    using (var stream = File.OpenWrite(filename))
    {
        using (var writer = new StreamWriter(stream))
        {
            foreach (string line in allusernames)
            {
                writer.WriteLine(line);
            }
        }
    }
