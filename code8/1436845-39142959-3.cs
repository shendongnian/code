    public static IEnumerable<string> ReadLines(string filename)
    {
        return ReadLines(() => File.OpenText(filename));
    }
    private static IEnumerable<string> ReadLines(Func<TextReader> readerProvider)
    {
        using (var reader = readerProvider())
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
