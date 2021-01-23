	public static class WebClientEx
	{
		public static T Using<T>(this Func<WebClient, T> factory)
		{
			using (var wc = new WebClient()
			{
				return factory(wc);
			}
		}
	}
