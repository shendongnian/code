	public class ResourceResponseModel
	{
		[JsonProperty(Order = 0)]
		public string Href { get; private set; }
		[JsonProperty(Order = 0)]
		public string Id { get; private set; }
		protected ResourceResponseModel(string id)
		{
			Id = id;
		}
	}
