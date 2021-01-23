	private static LookUpCodeCollection Deserialize(string input, Type toType)
	{
		System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(toType);
		
		using (StringReader sr = new StringReader(input))
		{
			return (LookUpCodeCollection)ser.Deserialize(sr);
		}
	}
