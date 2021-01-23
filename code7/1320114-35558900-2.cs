    Mapper.AddMap<Customer, CustomerInput>(src =>
    {
        var res = new CustomerInput();
        res.InjectFrom(src); // maps properties with same name and type
        res.FullName = src.FirstName + " " + src.LastName;
        return res;
    });
