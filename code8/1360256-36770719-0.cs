    [HttpPost]
     public ActionResult SearchFunction(string txtFirstName)
      {
              CustomerDal dal = new CustomerDal();
             string searchValue = txtFirstName;
             List<Customer> customers = (from x in dal.Customers 
                                where x.FirstName.Contains(searchValue)
                                select x).ToList<Customer>();
             CustomerModelView customerModelView = new CustomerModelView();
            customerModelView.Customers = customers;
           return View("ShowSearch", customerModelView);
      }
