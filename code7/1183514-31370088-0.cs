    var allManagers = d.Stores.Select(m => m.StoreManager).Union(d.Stores.Select(m => m.InventoryManager))
                                                          .Union(d.Warehouses.Select(m => m.WarehouseManager));
    foreach (Manager m in allManagers)
    {
        Console.WriteLine("{0}:{1}", m.Id, m.Name);
    }   
 
