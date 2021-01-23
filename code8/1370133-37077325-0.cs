    static void Main(string[] args)
    {
        var lines = @"A,B,C
    1,2,3
    4,5,6".Replace("\r", "").Split('\n');
        var csv = lines.Select(l => l.Split(',')).ToList();
        var headers = csv[0];
        var dicts = csv.Skip(1).Select(row => Enumerable.Zip(headers, row, Tuple.Create).ToDictionary(p => p.Item1, p => p.Item2)).ToArray();
        string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dicts);
        Console.WriteLine(json);
    }
