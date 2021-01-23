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
    // Use the GroupBy method to group the customers by the StoreID
    // Then, select the grouped data into a Dictionary.
    // Use the StoreID as the key
    // To make TValue a List<Customer> call ToList on the IGrouping.
    Dictionary<Guid, List<Customer>> result = customers.GroupBy(obj => obj.StoreId).ToDictionary(k => k.Key, v => v.ToList());
