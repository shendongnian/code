    var customerData =GetAllCustomer();
    
    ViewBag.customerfirstname = new SelectList(customerData
                                               .Select(
                                                       t=>new 
                                                         { 
                                                          FirstName = t.firstname,
                                                         CustomerID = customerId),
                                              "CustomerID",
                                              "FirstName");
