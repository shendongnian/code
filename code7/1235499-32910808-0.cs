    var nullDate = DateTime.Parse("1900-01-01 00:00:00.000");
    if (customer.CustomerOptions.Birthday.HasValue && customer.CustomerOptions.Birthday.Value != nullDate)
    {
        dtBirthday.Value = customer.CustomerOptions.Birthday.Value;
    }
    
    if (customer.CustomerOptions.Anniversary.HasValue && customer.CustomerOptions.Anniversary.Value != nullDate)
    {
        dtAnniv.Value = customer.CustomerOptions.Anniversary.Value;
    }
