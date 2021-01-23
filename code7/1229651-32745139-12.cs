	public class PageResult<T> where T : class
	{
	
		public PageResult(IEnumerable<T> items, int page = 1)
		{
			this.Items = items;
			this.PaginateData(1);
		}
	
		public IEnumerable<T> Items { get; set; }
	
	
		private int _pageSize = 10;
		public int PageSize
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
		public void PaginateData(int page)
		{
			if(this.Items == null) return;
			this.Total = this.Items.Count();
			this.PageIndex = page - 1;
			this.Items = this.Items.Skip(this.PageSize * this.PageIndex).Take(this.PageSize);
		}
	}
