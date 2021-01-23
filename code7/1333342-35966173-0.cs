    public static List<Definitions> ReadDefinitions2()
    {
        var files = (from name in Directory.EnumerateFiles(Settings.NotecadddyDefinitionsFolder)
                     select new Definitions 
                     {
                         Name = Path.GetFileNameWithoutExtension(name),
                         Id = File.ReadLines(name).Skip(2).First()
                     }).ToList();
        foreach (Definitions f in files)
        {
            Console.WriteLine(f.Name);
            Console.WriteLine(f.Id);
        }
        return files;
    }
