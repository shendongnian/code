    [HttpPost]
    public ActionResult NewClient(NewClientModel newClientModel)
    {
        if (!ModelState.IsValid)
        {
            // handle validation
        }
    
        var billingModel = new BillingModel
        {
            NewClientModel = newClientModel
        };
    
        return RedirectToAction("Billing", billingModel);
    }
