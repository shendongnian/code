	public static T Deserialize<T>(string jsonFile)
	{
		T myObject = default(T);
		try
		{
			using (var r = new StreamReader(jsonFile))
			{
				var serializer = new JavaScriptSerializer();
				string json = r.ReadToEnd();
				myObject = serializer.Deserialize<T>(json);
			}
		}
		catch (Exception ex)
		{
		}
		return myObject;
	}
