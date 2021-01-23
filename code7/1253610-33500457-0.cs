    static void Main(string[] args)
    {
        string path = "XMLFile1.xml";
        XDocument xdoc = XDocument.Load(path);
        var ops = xdoc.Descendants("OPERATION")
            .Elements()
            .Select(n => n.ToString())
            .ToList<string>();
        ops.ForEach(s => Console.WriteLine(s));
    }
