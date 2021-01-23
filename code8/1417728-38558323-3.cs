    public ActionResult Create()
    {
        var model = new CustomerVM();
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CustomerVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model)
        }
        var customer = new Customer
        {
            Code = model.Code,
            Amount = model.Amount
        }
        .... // save the Customer and redirect
    }
    
