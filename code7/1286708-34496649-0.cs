    public static class WebBrowserExtensions
	{
		public static void NavigateWithAuthorization(this WebBrowser browser, Uri uri)
		{
			byte[] authData = System.Text.Encoding.UTF8.GetBytes("user:password");
			string authHeader = "Authorization: Basic " + Convert.ToBase64String(authData) + "\r\n" + "User-Agent: MyUserAgent\r\n";
			browser.Navigate(uri, "", null, authHeader);
		}
	}
