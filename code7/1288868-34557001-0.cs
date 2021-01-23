    public override void RegisterArea(AreaRegistrationContext context)
    {
    	context.MapRoute(
    		"Documents",
    		"Public/Documents/Download/{fileName}",
    		 new { action = "Download", controller = "Documents", area = "Public" });
    
    	context.MapRoute(
    		"Public_default",
    		"Public/{controller}/{action}/{id}",
    		new { action = "Index", id = UrlParameter.Optional, area = "Public" }
    	);    
    }
