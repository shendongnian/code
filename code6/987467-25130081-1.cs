    byte[] bytes;
	using (MemoryStream stream = new MemoryStream())
	{
		IFormatter formatter = new BinaryFormatter();
		formatter.Serialize(stream, myObject);
		bytes = stream.ToArray();
	}
	using (MemoryStream stream = new MemoryStream(bytes))
	{
		IFormatter formatter = new BinaryFormatter();
		myObject = formatter.Deserialize(stream);
	}
