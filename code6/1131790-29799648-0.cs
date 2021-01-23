	foreach (JToken property in result)
	{
		var arrays = property.Children<JArray>();
		foreach (var array in arrays)
		{
			foreach (var item in array)
			{
				var val = item.Value<string>("KEY_VALUE");
				Console.WriteLine(val);
			}
		}
	}
    // output: value1, value2
    
