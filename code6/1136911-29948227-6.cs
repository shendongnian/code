	public class MyViewModel
	{
		public MyViewModel()
		{
			this.Sites = new List<Site>();
		}
		
		public int ID { get; set;}
		public Student Students { get; set; }
		public DateTime Date  { get { return DateTime.Now; } }
		public bool Criteria { get; set; }		
		
		public List<Site> Sites { get; set; }
	}
