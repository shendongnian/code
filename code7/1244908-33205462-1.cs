    var invoice = (from i in db.Invoices
        select new CombinedViewModel
        {
            InvoiceViewModel = new InvoiceViewModel {
                Quantity = i.Quantity
            },
            CustomerViewModel = new CustomerViewModel {
                // whatever goes here
            }
        });
