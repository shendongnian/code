    var mySmallCustomer = someService.GetCustomer(); // from sproc
    mySmallCustomer.col2 = "updated";
    var myLargeCustomer = new Customer();
    context.Customers.Attach(myLargeCustomer);
    Entry(myLargeCustomer).CurrentValues.SetValues(mySmallCustomer);
    // Here it comes:
    Entry(myLargeCustomer).Property(c => c.col2).IsModified = true;
    context.Configuration.ValidateOnSaveEnabled = false;
    context.SaveChanges();
