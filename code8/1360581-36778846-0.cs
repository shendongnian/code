    public static Dictionary<string, string> Data_Entry(string dataEntity, string dataCategory, string dataStream = "")
    {
        var lines = File.ReadAllLines(@"C:\MyFile.csv");
        var header = lines.First().Split(',');
        return (from line in lines.Skip(1)
            let cols = line.Split(',')
            where cols[0].ToUpper() == dataEntity & cols[1].ToUpper() == dataCategory & cols[4].ToUpper() == dataStream
            select header.Select((h, i) => new { header = h, index = i })
            .ToDictionary(o => o.header, o => cols[o.index])
        ).FirstOrDefault();
    }
