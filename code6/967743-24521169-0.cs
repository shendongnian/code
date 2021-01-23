    var results =
        AvailableInventory.GroupBy(i => i.Date.Date)
                          .Where(g => !SelectedProducts.Select(p => p.ID)
                                                       .Except(g.Select(i => i.ID))
                                                       .Any())
                          .SelectMany(g => g);
