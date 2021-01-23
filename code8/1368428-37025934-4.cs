    public ActionResult Profile()
    {
         CustomerViewModel customerViewModel = new CustomerViewModel();
         customerViewModel.Customers = customerRepository.GetAll();
         customerViewModel.StoreName = "Test Store Name";
    
         return View(customerViewModel);
    }
