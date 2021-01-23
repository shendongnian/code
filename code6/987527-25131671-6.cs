    using (StreamReader reader = new StreamReader(oldPath))
    using (StreamWriter writer = new StreamWriter(newPath))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
           int semicolon = line.IndexOf(';');
           if (semicolon > -1)
               line = c.Remove(semicolon);
           writer.WriteLine(line);
        }
    }
