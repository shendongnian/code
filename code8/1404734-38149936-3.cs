	[MvcSiteMapNode(Title="Category 1 Events", ParentKey="Events", Key="RunningEvents", Attributes = @"{ ""category"": ""Category1"" }")]
	[MvcSiteMapNode(Title="Category 2 Events", ParentKey="Category2", Key="Category2RunningEvents", Attributes = @"{ ""category"": ""Category2"" }")]
	public ActionResult RunningEvents()
	{
		return View();
	}
