    var customerList = JsonConvert.DeserializeObject<CustomerList>(json);
    
    foreach (var obj in customerList.Customers)
    {
        string Name = obj.Name;
        string Code = obj.Code;
        string Contact = obj.Address.Contact;
        string City = obj.Address.City;
        // etc.
    }
