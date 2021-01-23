    orders.GroupBy(_ => _.ID).Select(grp => grp.Aggregate((a,b) => new order
        {
            guid = a.guid,
            parent = a.parent,
            ProductID = a.ProductID,
            Description = a.Description,
            Quantity = a.Quantity + 1,
            Total = a.Total + b.Total
        }
    ));
