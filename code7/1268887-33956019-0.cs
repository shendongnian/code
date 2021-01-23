	public class Document
	{
		public int Id { get; set; }
		public string BaseUrl { get; set; }
		public string Name { get; set; }
		public int Active { get; set; }
		public Page[] Pages { get; set; }
	}
	public class Page
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public string InternalId { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
	}
