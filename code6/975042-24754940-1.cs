    using (var writer = new StreamWriter(newFile))
    using (var reader = new StreamReader(oldFile))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            if (shouldInsert(line))
                writer.WriteLine(line);
        }
    }
