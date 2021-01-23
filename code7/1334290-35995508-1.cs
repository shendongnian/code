	public string GetHomePage()
	{
		string startURL = "http://www.mypage.com/";
		string[] splits = null;
		using (var browser = new IE(startURL))
		{
			string browserURL = browser.Url;
			splits = browserURL.Split(new string[] { startURL }, StringSplitOptions.None);
		}
		return splits[1];
	}
