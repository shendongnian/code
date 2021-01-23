    using (var writer = new StreamWriter(newFile))
    {
        foreach (var line in File.ReadAllLines(oldFile))
        {
            if (shouldInsert(line))
                writer.WriteLine(line);
        }
    }
