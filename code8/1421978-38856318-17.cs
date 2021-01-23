    static IEnumerable<string> ReadLines(string path)
    {
        var sr = new StreamReader(Assets.Open(path));
        try
        {
            string line;
            while ((line = sr.ReadLine()) != null)
                yield return line; 
        }
        finally { sr.Dispose(); }
    }
