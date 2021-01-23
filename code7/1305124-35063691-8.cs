	public static T Clone<T>(this T source)
	{
		if (Object.ReferenceEquals(source, null))
			return default(T);
		using (var stream = new MemoryStream())
		{
			var formatter = new BinaryFormatter();
			formatter.Serialize(stream, source);
			stream.Position = 0;
			return (T) formatter.Deserialize(stream);
		}
	}
