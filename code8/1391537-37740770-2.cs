    Public Customer[] QueryCustomers(Func<Customer,bool> predicate)
    {
        var result =  db.Customers.Where(c=> predicate(c)).ToArray();
        return result;
    }
