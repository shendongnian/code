    var tmp = _db.Customers.Select(c =>
        new CustomerVM
        {
            Name = c.Name,
            Products = c.Products.Select(p => new ProductVM { ProductName = p.ProductName }).ToList()
        }
    )
