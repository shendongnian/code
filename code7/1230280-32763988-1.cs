	public RootObject LoadData(string filename)
	{
		using (XmlSerializer sr = new XmlSerializer(typeof(RootObject)))
		{
			TextReader reader = new StreamReader(filename);
			return (RootObject)sr.Deserialize(writer, obj);
		}
	}
	public RootObject SaveData(string filename, RootObject objectToSerialize)
	{
		using (XmlSerializer sr = new XmlSerializer(typeof(RootObject)))
		{
			TextWriter writer = new StreamWriter(filename);
			sr.Serialize(writer, objectToSerialize);
		}
	}
