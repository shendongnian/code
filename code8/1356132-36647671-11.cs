    [HttpGet]
    public ActionResult GetResults()
    {
        var dataFromStoredProc=db.Search(Country, state, city, str);
    			
    	// Translate the addressSerachResultModel to AddressSearchResultModel
    	var addressSearchResultModel= new AddressSearchResultModel();
    	var addressModel= new AddressModel()
    	foreach(var item in dataFromStoredProc )
    	{
    		//Assing every property from the dataFromStoredProc to AddressModel
    		//and add it to the list
    	    addressSearchResultModel.Add(AddressModel);
    	}
    			
    	return View(addressSearchResultModel);       
    }
    		
