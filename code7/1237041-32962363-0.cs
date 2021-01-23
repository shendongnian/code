    using (var sr = new StreamReader(dataStream, Encoding.UTF8))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            list.Add(line);
        }
    }
