    public static class Cookies
	{
		static readonly CookieContainer _cookies = new CookieContainer();
		public static CookieContainer All
		{
			get
			{
				return _cookies;
			}
		}
	}
