    Customer customer = new Customer
    {
        ProductDescription = tbDescription.Text,
        Fname = tbFName.Text,
        Lname = tbLName.Text
    };
    
    
    string creditApplicationJson = JsonConvert.SerializeObject(
        new
        {
            jsonCreditApplication = customer
        });
