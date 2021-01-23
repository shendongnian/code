    public static void Save(List<DTOSaveFromFile> Items)
    {
        using (StreamWriter sw = File.AppendText(path))
        {
            foreach(DTOSaveFromFile d in Items)
                sw.WriteLine(d.Serialize(), Encoding.Default);
        }
    }
