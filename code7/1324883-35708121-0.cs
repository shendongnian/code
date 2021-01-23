    public void WriteConfiguration(IConfiguration data, Stream stream)
    {
         using (var writer = new StreamWriter(stream))
         {
             new Serializer().Serialize(writer, data.GetAllProperties());
         }
    }
