    public static class SessionWrapper
    {
		private const string GroupKey = "Group";
		private const string RegionKey = "Region";
		private const string IDKey = "Id";
              
		public static string Group 
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
		
		public static string Region
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
        public static string ID
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
