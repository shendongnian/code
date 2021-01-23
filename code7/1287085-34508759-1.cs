    public static void Save(List<DTOSaveFromFile> Items)
    {
        using (var sw = File.AppendText(path)) 
            sw.WriteLine(from i in Items select i.Serialize()).ToArray(), Encoding.Default);
    }
