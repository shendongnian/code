    public ActionResult Contact()
    {
       Customer customer = TempData.Peek("Customer") as Customer;
       if (customer == null)
       {
          customer = new Customer();
       }   
       return View();
    }
