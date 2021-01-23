    // List of selected products from user 
    List<SelectedProduct> SelectedProducts = new List<SelectedProduct> {
        new SelectedProduct { ID = 1, Qty = 2 },
        new SelectedProduct { ID = 2, Qty = 4 },
        new SelectedProduct { ID = 5, Qty = 10 }
    };
    // populated from service with all dates for all products
    List<AvailableInventory> AvailableInventory = new List<AvailableInventory> {
        new AvailableInventory { ID = 1, Date = new DateTime(2014, 04, 01) },
        new AvailableInventory { ID = 2, Date = new DateTime(2014, 04, 02) },
        new AvailableInventory { ID = 3, Date = new DateTime(2014, 04, 02) },
        new AvailableInventory { ID = 4, Date = new DateTime(2014, 04, 10) },
        new AvailableInventory { ID = 5, Date = new DateTime(2014, 04, 10) }
    };
