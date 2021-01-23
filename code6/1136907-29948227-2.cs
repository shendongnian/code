	public class Site
	{
		public Site(int id, string siteName)
		{
			this.ID = id;
			this.SiteName = siteName;
		}
		public int ID { get; set; }
		public string SiteName { get; set; }
	}
	public class MyViewModel
	{
		public MyViewModel()
		{
			this.Sites = new List<Site>();
		}
		
		public List<Site> Sites { get; set; }
	}
