    public static void Serialize(object value, string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(fStream, value);
        }
    }
