    foreach (IGrouping<Guid, Customer> grp in customers.GroupBy(obj => obj.StoreId))
    {
        Guid storeID = grp.Key;
        IEnumerable<Customer> customerCollection = grp;
        foreach (Customer customer in customerCollection)
        {
            // Insert code here.
        }
    }
