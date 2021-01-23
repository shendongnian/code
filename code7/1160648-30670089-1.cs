    using System.IO;
    static void Main(string[] args)
    {
        var reader = new StreamReader(File.OpenRead(@"C:\YouFile.csv"));
        List<string> listRows= new List<string>();
        while (!reader.EndOfStream)
        {
            listRows.Add(reader.ReadLine());
        }
    }
