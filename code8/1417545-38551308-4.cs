    context.Transactions.AddOrUpdate(
        //t => t.Products,   //comment this
        new Transaction { 
            Products = new List<Product>(
                            pr.Where(p => p.Name == "Book" || p.Name == "Table")) 
        },
        new Transaction
        {
            Products = new List<Product>(
                    pr.Where(p => p.Name == "Chair" || p.Name == "Book" || p.Name == "Table"))
        }
    );
