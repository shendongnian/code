	public class ResourceResponseModel
	{
		[JsonProperty(Order = -2)]
		public string Href { get; private set; }
		[JsonProperty(Order = -2)]
		public string Id { get; private set; }
		protected ResourceResponseModel(string id)
		{
			Id = id;
		}
	}
