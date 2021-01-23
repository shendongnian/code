    using (new Sitecore.SecurityModel.SecurityDisabler())
    {
    	string itemId = "E7A2DE22-4338-49A6-840F-4B3124F1FFBD";
    
    	Database webdb = Sitecore.Configuration.Factory.GetDatabase("web");
    	Database masterdb = Sitecore.Configuration.Factory.GetDatabase("master");
    
    	ClearSitecoreDatabaseCache(masterdb);
    
    	Item masterItem = masterdb.GetItem(new ID(itemId));
    
    	// target databases
    	Database[] databases = new Database[1] { webdb };
    
    	Sitecore.Handle publishHandle = Sitecore.Publishing.PublishManager.PublishItem(masterItem, databases, webdb.Languages, true, false);
    
    	ClearSitecoreDatabaseCache(webdb);
    }
