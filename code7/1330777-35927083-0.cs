    var item = new Item { Id = 1, Description = "Product" };
            
    // Invoice is added
    var invoice = new Invoice
    {
        State = State.Added,
        Number = "SALE-001",
        Lines =
        {
            new InvoiceLine
            {
                State = State.Added,
                Price = 10,
                Quantity = 1,
                // Item = new Item { Id = 1, Description = "Product" }
                Item = item
            },
            new InvoiceLine
            {
                State = State.Added,
                Price = 10,
                Quantity = 1,
                DiscountPercentage = 50,
                // Item = new Item { Id = 1, Description = "Product" }
                Item = item
            },
        }
    };
