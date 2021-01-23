    public ActionResult Example()
    {
    	BankAccount Model = new BankAcount(20);
    	Model.Variable = Modify.Me;
    	...
    
    	return View(Model);
    }
