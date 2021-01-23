	public static string ChangeNumericalPropertyNames(JsonReader reader)
	{
		JObject jo = JObject.Load(reader);
		ChangeNumericalPropertyNames(jo);
		return jo.ToString();
	}
	
	public static void ChangeNumericalPropertyNames(JObject jo)
	{
		foreach (JProperty jp in jo.Properties().ToList())
		{
			if (jp.Value.Type == JTokenType.Object)
			{
				ChangeNumericalPropertyNames((JObject)jp.Value);
			}
			else if (jp.Value.Type == JTokenType.Array)
			{
				foreach (JToken child in jp.Value)
				{
					if (child.Type == JTokenType.Object)
					{
						ChangeNumericalPropertyNames((JObject)child);
					}
				}
			}
			
			if (Regex.IsMatch(jp.Name, @"^\d"))
			{
				string name = "n" + jp.Name;
				jp.Replace(new JProperty(name, jp.Value));
			}
		}
	}
