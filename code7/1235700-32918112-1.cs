	List<bmData> namesValues = new List<bmData>
	{
		new bmData { name = "Name1", value= 1 },
		new bmData { name = "Name2", value= 2 },
		new bmData { name = "Name3", value= 3 }
	};
	string jsData = "[]";
	var serializer = new JsonSerializer();
	using (var stringWriter = new StringWriter())
	{
		using (var writer = new JsonTextWriter(stringWriter))
		{
			writer.QuoteName = false;
			serializer.Serialize(writer, namesValues);
		}
		jsData = stringWriter.ToString();
	}
