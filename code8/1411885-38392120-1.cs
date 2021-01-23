    using (var customWriter = new CustomWriter(path, Encoding.UTF8))
    {
        customWriter.Formatting = Formatting.Indented;
        customWriter.Indentation = 1;
        customWriter.IndentChar = '\t';
                
        ser.Serialize(customWriter, GetDataToSerialize(), ns);
    }
