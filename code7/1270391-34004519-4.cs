    internal T DeserializeXML<T>(String XMLRoot, String Filename)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(XMLRoot));
		using (StreamReader reader = new StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(Filename)))
		{
			return (T)serializer.Deserialize(reader);
		}
	}
