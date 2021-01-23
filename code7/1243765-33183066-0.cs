	public void GenericWriter<T>(ref XmlWriter writer, string propertyName, T property)
	{
		writer.WriteStartElement(propertyName);
		var xmlSerializer = new XmlSerializer(typeof(T));
		xmlSerializer.Serialize(writer, property);
		writer.WriteEndElement();
	}
