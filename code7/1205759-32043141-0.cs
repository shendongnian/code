	public static class WebBrowserExtensions
	{
		public static void Navigate(this IWebBrowser2 browser, string url)
		{
			browser.Navigate(url, /* fill in arguments as necessary*/)
		}
	}
