    public static void SaveData(object obj, string Filename)
    {
        File.Delete(Filename);
        XmlSerializer sr = new XmlSerializer(obj.GetType());
        TextWriter writer = new StreamWriter(Filename, true);
        sr.Serialize(writer, obj);
        writer.Close();
    }
