	[System.Web.Http.Route("api/readandreturnjson")]
    [System.Web.Http.HttpGet]
	public async Task<IHttpActionResult> ReadAndReturnJsonAsync()
	{
        // object to return through the API (it'll be serialized by WebAPI)
		object obj = null;
        // WebClient used to download the JSON file
		using (var wc = new WebClient())
		{
			var url =
			"https://pptlbhstorage.blob.core.windows.net/temperature/0_7622a22009224c78a46c0b2bc0a3fd82_1.json";
            // Used to hold and add a ']' to the downloaded JSON
			StringBuilder builder = new StringBuilder();
			builder.Append(await wc.DownloadStringTaskAsync(url));
			builder.Append("]");
            // Deserialize the now valid JSON into obj
			obj =  JsonConvert.DeserializeObject(builder.ToString());
		}
        // return the json with 200 Http status.
		return Ok(obj);
	}
