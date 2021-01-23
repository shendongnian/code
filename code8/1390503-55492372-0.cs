    using (var context = new MyContext())
    {
        var customers = context.Customers
                .Include(i => i.Invoices)
                    .ThenInclude(it => it.Items))
                .ToList();
    }
