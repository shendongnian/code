    public static void Save(List<DTOSaveFromFile> Items)
    {
        using (StreamWriter sw = File.AppendText(path)) 
        {
            sw.WriteLine(from i in Items select i.Serialize()).ToArray(), Encoding.Default);
        }	
    }
