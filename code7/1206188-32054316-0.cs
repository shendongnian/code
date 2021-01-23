    void PrintCharCount(string filePath)
    {
        if (!String.IsNullOrEmpty(filePath))
        {
             var query = File.ReadLines(filePath).Where(line => !String.IsNullOrEmpty(line))
                                                 .GroupBy(line => line.First());
             foreach (var group in query)
                 Console.WriteLine(g.Key + ": " + g.Count());
        }
    }
