    private void CheckJsonSerialization()
    {
       var ms = new MemoryStream();
       var writer = new StreamWriter(ms);
       writer.WriteLine("Test string");
       writer.Flush();
       ms.Position = 0;
       var json = JsonConvert.SerializeObject(ms, Formatting.Indented, new MemoryStreamJsonConverter());
       var ms2 = JsonConvert.DeserializeObject<MemoryStream>(json, new MemoryStreamJsonConverter());
       var reader = new StreamReader(ms2);
       var deserializedString = reader.ReadLine();
       Console.Write(json);
       Console.Write(deserializedString);
       Console.Read();
    }
