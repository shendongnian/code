    private void Save(List<string> words)
    {
        StringBuilder contents = new StringBuilder();
        foreach (string s in words)
        {
            contents.AppendLine(s);
        }
        System.IO.File.WriteAllText(@"Data.txt", contents);
    }
