    public void Main()
	{
		string json = @"{""Name"": ""foo""} {""Name"" : ""bar""} {""Name"" : ""baz""}";
		IEnumerable<dynamic> deserialized = DeserializeObjects(json);
        string name = deserialized.First().Name; //name is "foo"
	}
	IEnumerable<object> DeserializeObjects(string input)
	{
		JsonSerializer serializer = new JsonSerializer();
		using (var strreader = new StringReader(input)) {
			using (var jsonreader = new JsonTextReader(strreader)) {
				jsonreader.SupportMultipleContent = true;
				while (jsonreader.Read()) {
					yield return serializer.Deserialize(jsonreader);
				}
			}
		}
	}
