      private ObservableCollection<Invoice> Get()
        {
            using (var ctx = new Context())
            {
            DateTime date2 = DateTime.Now.AddMonths(-2);
    
            var query = ctx.Invoices
                        .GroupBy(x => new { x.suppInvNumber, x.shop1, x.date, x.foodSupplier })
                        .ToList()
                        .Select(i => new Invoice
                        {
                            suppInvNumber = i.Key.suppInvNumber,
                            shop1 = i.Key.shop1,
                            date = i.Key.date,
                            foodSupplier = i.Key.foodSupplier,
                            totalPrice = i.Sum(t => t.totalPrice),
                        })
                        .Where(d => d.date >= date2)
                        .OrderByDescending(d => d.date)
                        .AsQueryable();
    
            invoiceCollection = new ObservableCollection<Invoice>(query);
            }
            return invoiceCollection;
        }
