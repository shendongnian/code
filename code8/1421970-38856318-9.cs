    static IEnumerable<string> ReadLines(string path)
    {
        using (var sr = new StreamReader(Assets.Open(path)))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
                yield return line; 
        }
    }
