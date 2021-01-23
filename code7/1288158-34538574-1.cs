    public void Get()
    {
    	string jsonString = JsonConvert.SerializeObject(datatable, Formatting.Indented);
    
    	string path = HttpContext.Current.Server.MapPath("~/App_Data/");
    
    	//Generate a filename with your logic..
    	string fileName = string.Concat(Guid.NewGuid().ToString(), ".json");
    
    	//Create the full Path
    	string fullPath = System.IO.Path.Combine(path, fileName);
    
    	//Create the json file
    	System.IO.File.WriteAllText(fullPath, jsonString);
    }
