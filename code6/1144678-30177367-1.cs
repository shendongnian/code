    public class MyModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		public Details details { get; set; }
		
		[JsonIgnore]
		public string[] Size
		{
			get
			{
				return details != null ? details.size : null;
			}
			set
			{
				if (details == null)
				{
					details = new Details();
				}
				details.size = value;
			}
		}
		
		[JsonIgnore]
		public string Weight
		{
			get
			{
				return details != null ? details.weight : null;
			}
			set
			{
				if (details == null)
				{
					details = new Details();
				}
				details.weight = value;
			}
		}
	}
