    int count = dictionary.Count(D => D.Key.StartsWith("location-"));
	Dictionary<string, string> values = new Dictionary<string, string>();
	for (int i = 1; i <= count; i++)
	{
		if (dictionary.ContainsKey("location-"+i))
		{
			string locationData = dictionary["location-"+i];
			string[] locationDataRow = locationData.Split(':');
			values.Add(locationDataRow[0],locationDataRow[1]);
		}
	}
	foreach (var item in values)
	{
		Debug.WriteLine(item.Key + " : " + item.Value);
	}
