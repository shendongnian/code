    public static void Main(string[] args)
    {
        HashSet<MyLine> lines = new HashSet<MyLine>();
        var line = new MyLine(new MyPoint("a"), new MyPoint("b"));
        if (!lines.Contains(line))
        {
            lines.Add(line);
        }
    }
