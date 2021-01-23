	public class ResourceResponseModel
	{
		[JsonProperty(Order = -1)]
		public string Href { get; private set; }
		[JsonProperty(Order = -1)]
		public string Id { get; private set; }
		protected ResourceResponseModel(string id)
		{
			Id = id;
		}
	}
