    using (FileStream fs = File.Create(sfDialog.FileName, 2048, FileOptions.None))
    {
        BinaryFormatter deserializer = new BinaryFormatter();
        deserializedObject = System.Text.Encoding.Unicode.GetString((byte[])deserializer.Deserialize(memoryStream));
    }
