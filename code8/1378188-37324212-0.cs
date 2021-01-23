	class Territory
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("center")]
		public IList<int> Center { get; set; }
		[JsonProperty("timeZoneCode")]
		public string TimeZoneCode { get; set; }
		[JsonProperty("languageCode")]
		public string LanguageCode { get; set; }
	}
