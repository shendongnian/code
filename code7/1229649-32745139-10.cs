		public class PageResult<T> where T : class
	{
		public IEnumerable<T> Items { get; set; }
	
	
		private int _pageSize = 10;
		public private int PageSize
		{
			get { return _pageSize; }
			set { _pageSize = 10; }
		}
		
	
		public int PageIndex { get; set; }
	
		public int Total { get; set; }
	
		public int TotalPages
		{
			get
			{
				return Math.Max((int)Math.Ceiling((Total / (double)PageSize)), 1);
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
				return Math.Min(this.MaxPagesToDisplay, TotalPages);
			}
		}
	
	}
