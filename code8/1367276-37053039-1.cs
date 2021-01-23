    public class Custom404Resolver : HttpRequestProcessor
    {
    	public override void Process(HttpRequestArgs args)
    	{
    		Assert.ArgumentNotNull(args, "args");
    
    		// Do nothing if the item is actually found
    		if (Sitecore.Context.Item != null || Sitecore.Context.Database == null)
    			return;
    
    		// all the icons and media library items for the sitecore client need to be ignored
    		if (args.Url.FilePath.StartsWith("/-/"))
    			return;
    
    		// Get the page not found item in Sitecore.
    
    		var notFoundPagePath = Sitecore.IO.FileUtil.MakePath(Sitecore.Context.Site.StartPath, "Errors/page-not-found");
    		var notFoundPage = Sitecore.Context.Database.GetItem(notFoundPagePath);
    
    		if (notFoundPage == null)
    		{ 
    			var notFoundPageId = Sitecore.Configuration.Settings.GetSetting("Namespace.PageNotFound.ID", "{017424DE-DB4F-4D9E-9AA1-5326527CC6A3}");
    			notFoundPage = Sitecore.Context.Database.GetItem(notFoundPageId);
    		}
    		if (notFoundPage == null)
    			return;
    
    		// Switch to the 404 item
    		Sitecore.Context.Item = notFoundPage;
    	}
    }
