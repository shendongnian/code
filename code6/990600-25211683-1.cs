    using (StreamWriter writer = new StreamWriter(memstream))
    {
        data.ForEach(line =>
        {
            writer.WriteLine(string.Join(",", line));
        });
    }
