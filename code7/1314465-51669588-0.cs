	catch (Exception e)
	{
		var error = new Dictionary<string, string>
		{
			{"Type", e.GetType().ToString()},
			{"Message", e.Message},
			{"StackTrace", e.StackTrace}
		};
		foreach (DictionaryEntry data in e.Data)
			error.Add(data.Key.ToString(), data.Value.ToString());
		string json = JsonConvert.SerializeObject(error, Formatting.Indented);
		HttpResponseMessage response = new HttpResponseMessage();
		response.Content = new StringContent(json);
		return response;
	}
