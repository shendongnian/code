    public void WriteLineFromCollection<T>(T line) where T : IEnumerable<string>
    {
        string newLine = String.Join(",", line);
        base.WriteLine(newLine);
    }
