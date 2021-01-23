    public byte[] Serialize(ISpecificRecord record) 
        {
            using (var ms = new MemoryStream())
            {
                    var encoder = new BinaryEncoder(ms);
                    var writer = new SpecificDefaultWriter(record.Schema);
                    writer.Write(record, encoder);
                    return ms.ToArray();
             }
         }
