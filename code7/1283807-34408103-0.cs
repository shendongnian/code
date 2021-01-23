	string json = "{Id: \"2db55af1-109c-46aa-ba36-e61ae6e5a6e1\", Product: \"Generic Widget\", Price: 25.99, Quantity: 25, EditedOn: \"12/13/2015\"}";	
	dynamic deserialized = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());
	ClientRow cr = new ClientRow
	{
		Id = new Guid(deserialized.Id),
		EditedOn = DateTime.ParseExact(deserialized.EditedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture)
	};
	
	IDictionary<string, object> propertyValues = (IDictionary<string, object>)deserialized;
	foreach (var property in propertyValues)
	{
		if (!(property.Key.Equals("Id") || property.Key.Equals("EditedOn")))
		{
			cr.Data += property.Value.ToString() + " ";
		}
	}
	
    // cr now contains our final deserialized result
	Console.WriteLine(JsonConvert.SerializeObject(cr));
