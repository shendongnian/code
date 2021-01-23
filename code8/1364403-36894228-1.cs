    orders.GroupBy(_ => _.ID).Select(grp => grp.Aggregate((a,b) => new order
        {
            guid = a.guid,
            parent = a.parent,
            ProductID = a.ProductID,
            Description = a.Description,
            Quantity = a.Quantity + b.Quantity,
            Total = a.Total + b.Total
        }
    ));
