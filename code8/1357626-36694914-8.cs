    StoreLocatorController : UmbracoAuthorizedApiController // this allows only logged in users to call the api and also ensures that the correct umbraco context is set
    {
        public string basePath;
    
        public StoreLocatorController()
        {
            this.basePath = System.Web.Hosting.HostingEnvironment.MapPath(@"/App_Data/storeLocatorUpload/");
        }
    
        
        [HttpPost]
        public void Go()
        {
    		var myContext = Request.TryGetHttpContext();
    		if (myContext.Success)
    		{
    			HttpPostedFileBase myFile = myContext.Result.Request.Files["file"];
    			if (myFile == null)
    			{
    				throw new HttpException("invalid file");
    			}
    			// save the file
    			myFile.SaveAs(this.basePath + "file.ext");
    			
    			
    			
    			UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
    			// parse the data and insert them using UmbracoDatabase db
    			//..
    		}
    
    
    
    	}
    }
