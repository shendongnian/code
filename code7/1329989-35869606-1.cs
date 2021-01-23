    var website = Sitecore.Configuration.Factory.GetSite("website");
    using (new SiteContextSwitcher(website))
    {
    	var options = LinkManager.GetDefaultUrlOptions();
    	options.AlwaysIncludeServerUrl = true;
    	options.SiteResolving = true;
    	var url = LinkManager.GetItemUrl(item, options);
    }
