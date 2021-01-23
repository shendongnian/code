    public static void Save(List<DTOSaveFromFile> Items)
    {
        File.Create(dataPath);
        File.AppendAllLines(dataPath, (from i in Items select i.Serialize()).ToArray(), Encoding.Default);
    }
