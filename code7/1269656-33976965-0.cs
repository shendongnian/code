    public static ReportClass DeserializeRep(string FileWay)
    {
        using (Stream stream = File.Open(FileWay, FileMode.Open))
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            return (ReportClass)bformatter.Deserialize(stream);
        }
    }
