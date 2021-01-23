    internal void DeserializeXML<T>(String XMLRoot, Object Output, String Filename)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(XMLRoot));
		StreamReader reader = new StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(Filename));
		Output = (T)serializer.Deserialize(reader);
		reader.Close();
	}
