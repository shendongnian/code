    [HttpPost]
    public ActionResult CreateCustomer(Models.Customer model)
    {
        if (ModelState.IsValid)
        {
            string firstName = model.FirstName;
            int pinCode = model.Pincode;
            return Content("Customer first name is " + firstName);
        }
        else
        {
            return View("Index");
        }
    }
