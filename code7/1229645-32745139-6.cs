	public class PageResult<T> where T : class
	{
		public IEnumerable<T> Items { get; set; }
	
		public int PageSize { get; set; }
	
		public int Page { get; set; }
	
		public int Total { get; set; }
	
		public int TotalPages
		{
			get
			{
				return (int)Math.Ceiling((Total / (double)PageSize));
			}
		}
	
		private int _MaxPagesToDisplay = 10;
	
		public int MaxPagesToDisplay
		{
			get { return _MaxPagesToDisplay; }
			set { _MaxPagesToDisplay = value; }
		}
	
		public int PagesToDisplay
		{
			get
			{
				return Math.Max(this.MaxPagesToDisplay, TotalPages);
			}
		}
	
	}
