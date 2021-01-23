    static void Main(string[] args)
    {
        var dirs = Directory.GetFiles(@"C:\TestDirectory\", "MERSDLY.*");
        foreach (string file in dirs)
        {
            var parts = file.Split("."); 
            var year = new DateTime(int.Parse(parts[1].Substring(0,4)), 1, 1);
            year = year.AddDays(int.Parse(parts[1].Substring(4)) - 1);
            parts[1] = year.ToString("MM-dd-yyyy");
            File.Move(file,string.Join(".", parts));
        }
    }
