	class Person
	{
		public string FullName { get; set; }
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
		public double Score { get; set; }
		public bool IsStudent { get; set; }
		public double Weight { get; set; }
	}
