    //StringExtension.cs
	public static class StringExtension	{
		public static string ToJson(this string input)	{
			var parser = new JsonParser();
	    	var normalizer = new Normalizer();
		    var dataHandler = new DataHandler();
		    return normalizer.Normalize(parser.Parse(json));
		}
	}
	// in your class
	private void ReceiveData(string json)
	{
	    dataHandler.Handle(json.ToJson());
	}
