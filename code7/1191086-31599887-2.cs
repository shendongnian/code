	public static bool TryDeserialize<T>(string jsonFile, out T myObject)
	{
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
            myObject = default(T);
            return false;
		}
		return true;
	}
