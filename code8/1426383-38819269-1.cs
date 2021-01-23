    // Define this in your class
    enum FileType : byte
    {
        Extract = 0,
        Required = 1,
        Optional = 2,
    }
    static void Main(string[] args)
    {
        string input = "file0.txt:0 file1.txt:0 file2.txt:1 file3.txt:2 file4.txt:2 file5.txt:2";
        // create list of files
        var list = input.Split(' ').Select(file =>
        {
            var spl = file.Split(':');
            var type = (FileType)Enum.Parse(typeof(FileType), spl[1]);
            return new { Name = spl[0], Type = type };
        }).ToArray();
        // group by type and write to console
        var group = list.GroupBy(l => l.Type);
        foreach (var g in group)
        {
            Console.WriteLine("{0}: {1}", g.Key, String.Join(",", g.Select(a => a.Name)));
        }
    }
