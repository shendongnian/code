    public static IEnumerable<string[]> ReadFileAsLinesSets(string fileName, int setLen = 10)
    {
        using (var reader = new StreamReader(fileName))
            while (!reader.EndOfStream)
            {
                var set = new List<string>();
                for (var i = 0; i < setLen && reader.EndOfStream; i++)
                {
                    set.Add(reader.ReadLine());
                }
                yield return set.ToArray();
            }
    }
