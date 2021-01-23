    ObjectYourDatabaseIsLabeledAs.Products.OrderByDesc(o => o.Quantity)
        .FirstOrDefault(p => p.Prices
            .Any(pr => pr.EndDate >= DateTime.Today && pr.StartDate <= DateTime.Today)) && // Gets All With Valid Prices
        p.Quantity <= RequestedQuantity && // Removes all prices for higher quantities
        p.Id == ProductId) // Gets matching Ids
