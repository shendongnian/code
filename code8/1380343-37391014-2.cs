    [HttpPost]
    public ActionResult AddNewProduct(string name, string unit, string category, string company, String salerate, string purchaserate, string openingamount)
    {
    	// You perform the validations first which I am not including.
    	// If all validations are good, then you call the add method from the Products model
    
    	Products p = new Products();
    	bool check = p..SaveNewProduct(name, unitid, catid, compid, srate, prate, oamount);
    
    	if (check)
    	{
    	ViewBag.MessageType = "Success";
    	ViewBag.Message = "New Product added";
    	}
    }
