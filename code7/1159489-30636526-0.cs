	public class MySession
	{
	    private const string GroupKey = "Group";
    	private const string RegionKey = "Region";
        private const string IDKey = "Id";
		private static MySession _session;	
		public static MySession Current
		{
			get
			{
				return _session ?? (_session = new MySession());
			}
		}
		
		public string Group 
		{ 
			get
			{
				return HttpContext.Current.Session[GroupKey] as string;
			}
			set
			{
				HttpContext.Current.Session[GroupKey] = value;
			}
		}
		
		public string Region
		{
			get
			{
				return HttpContext.Current.Session[RegionKey] as string;
			}
			set
			{
				HttpContext.Current.Session[RegionKey] = value;
			}
		}
        public string ID
		{
			get
			{
				return HttpContext.Current.Session[IDKey] as string;
			}
			set
			{
				HttpContext.Current.Session[IDKey] = value;
			}
		}
	}
