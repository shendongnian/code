	// Deserializing XML string, exceptions now give line number	
	string serializedXmlString = .... XML string ...
	using (var reader = new StringReader(serializedXmlString))
	{
		var serializer = new XmlSerializer(typeof(T));
		return (T)serializer.Deserialize(reader);
	}
 
