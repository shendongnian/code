    public string ToXmlString()
    {
    	var builder = new StringBuilder();
    	var xmlSerializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(_rootNodeName));
    	using (writer = XmlWriter.Create(builder, new XmlWriterSettings { OmitXmlDeclaration = true })) {
    		xmlSerializer.Serialize(writer, _source);
    	}
    	return builder.ToString();
    }
  
