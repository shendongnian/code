	[TestMethod()]
	public void AreWebsitesTheSame()
	{
		using (var browser = new IE("www.mypage.com/"))
		{
			string url = "www.mypage.com/default.aspx";
			Assert.IsTrue(browser.Url == url);
		}
	}
