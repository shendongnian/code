    using System.IO;
    
    static void Main(string[] args)
    {
        var reader = new StreamReader(File.OpenRead(@"C:\test.csv"));
        List<string> listFlyingFrom = new List<string>();
        List<string> listFlyingTo = new List<string>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(';');
    
            listFlyingFrom.Add(values[0]);
            listFlyingTo.Add(values[1]);
        }
    }
