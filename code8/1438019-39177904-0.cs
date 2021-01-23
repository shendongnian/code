       var obj = (from invoice in db.tblinvoices
                  where invoice.ID == invoiceId
                  join items in db.tblinvoiceitems
                  on invoice.ID == items.InvoiceId
                  select new InvoiceCreateViewModel
                       {
                           AmountPaid = invoice.AmountPaid,
                           DueDate = invoice.DueDate,
                           InvoiceNo = invoice.ID,
                           UserId = invoice.UserId,
                           InvoiceItems = new List<InvoiceItemViewModel> {
                               Description = items.DESCRIPTION,
                               Quantity = items.Quantity,
                               Rate = items.Rate,
                               Id = items.ID,
                               InvoiceId = items.InvoiceId
                           }
                       }
                  ).SingleOrDefault();
