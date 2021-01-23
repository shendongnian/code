    List<CustomerTypeViewModel> obj = new List<CustomerTypeViewModel>();
    obj.Add(new CustomerTypeViewModel(){
      CustomerName = objCustomerName,
      CustomerType = customertype,
      SalesCount = salescount.ToString()
    });
    return View(obj);
