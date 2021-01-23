	public class PageResult<T> where T : class
	{
	
		public PageResult(IEnumerable<T> items, int page = 1, int pageSize = 10)
		{
			this.Items = items;
			this.PageSize = pageSize;
			this.PageIndex = page;
			this.PaginateData(page);
		}
	
		public IEnumerable<T> Items { get; private set; }
	
		public int PageSize { get; private set; }
		
		public int PageIndex { get; private set; }
	
		public int Total { get; private set; }
	
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
			this.Items = this.Items.Skip(this.PageSize * this.PageIndex - 1).Take(this.PageSize);
		}
	}
