    // List of selected products from user 
    List<SelectedProduct> SelectedProducts = new List<SelectedProduct> {
        new SelectedProduct { ID = 1, Qty = 1 },
        new SelectedProduct { ID = 2, Qty = 2 },
    };
    
    
    // populated from service with all dates for all products
    List<AvailableInventory> AvailableInventory = new List<AvailableInventory> {
        new AvailableInventory { ID = 1, Date = new DateTime(2014, 04, 11) },
        new AvailableInventory { ID = 2, Date = new DateTime(2014, 04, 11) },
        new AvailableInventory { ID = 1, Date = new DateTime(2014, 04, 12) },
        new AvailableInventory { ID = 2, Date = new DateTime(2014, 04, 13) },
        new AvailableInventory { ID = 1, Date = new DateTime(2014, 04, 14) },
        new AvailableInventory { ID = 2, Date = new DateTime(2014, 04, 14) },                
    };
                
    var query = AvailableInventory.GroupBy(i => i.Date)
        .Where(g => SelectedProducts.All(s => g.Any(i => i.ID == s.ID)));
    
    foreach(var group in query)
    {
        Console.WriteLine("Date: {0}", group.Key);
    
        foreach(var inventory in group)
        {
            Console.WriteLine("  Available: {0}", inventory.ID);
        }
    }
