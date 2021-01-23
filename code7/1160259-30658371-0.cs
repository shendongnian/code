    List<Customer> customers = new List<Customer>();
    customers.Add(new Customer() { CustomerId = 1, CustomerName = "Foo",    CustomerAddress="A", ContactNo = "1" });
    customers.Add(new Customer() { CustomerId = 2, CustomerName = "Bar", CustomerAddress="B", ContactNo = "2" });
    
    var customerQuery = customers.Select(c => new { CustomerId = c.CustomerId, DisplayText = c.CustomerAddress.ToString() + " " + c.ContactNo });
    
    skuDropDown.DataSource = customerQuery ;
    skuDropDown.DataValueField = "CustomerId";
    skuDropDown.DataTextField = "DisplayText";
    skuDropDown.DataBind();
