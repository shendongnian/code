    // Just populating some sample data.
    List<Guid> storeIDs = new List<Guid>
    {
        Guid.NewGuid(),
        Guid.NewGuid(),
        Guid.NewGuid(),
    };
    List<Customer> customers = new List<Customer>();
    customers.Add(new Customer { Id = Guid.NewGuid(), StoreId = storeIDs[0], Name = "John" });
    customers.Add(new Customer { Id = Guid.NewGuid(), StoreId = storeIDs[1], Name = "Jacob" });
    customers.Add(new Customer { Id = Guid.NewGuid(), StoreId = storeIDs[2], Name = "Schmidt" });
    customers.Add(new Customer { Id = Guid.NewGuid(), StoreId = storeIDs[0], Name = "May" });
    customers.Add(new Customer { Id = Guid.NewGuid(), StoreId = storeIDs[1], Name = "Naomi" });
    customers.Add(new Customer { Id = Guid.NewGuid(), StoreId = storeIDs[2], Name = "Tou" });
    // Use the GroupBy method to group the customers by the StoreID, then simply select the grouped data into a Dictionary, using the StoreID as the key, and  use ToList() on the grouped data so that the value contains a list of Customer objects.
    customers.GroupBy(obj => obj.StoreId).ToDictionary(k => k.Key, v => v.ToList());
