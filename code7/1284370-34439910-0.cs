	JObject response = JObject.Parse(jr);
	IList<JToken> results = response["Results"].Children().ToList();
	IList<User> searchResults = new List<User>();
	foreach (JToken result in results)
	{
		System.Diagnostics.Debug.WriteLine(result); //just to check my json data.
		User searchResult = JsonConvert.DeserializeObject<User>(result.ToString()); //get exception on this line.
		searchResults.Add(searchResult);
	}
