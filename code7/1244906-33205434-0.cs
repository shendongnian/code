    var invoice = (from i in db.Invoices
                               select new CombinedViewModel
                               {             
                                   //Not valid                  
                                   InvoiceViewModel=new InvoiceViewModel{Quantity = i.Quantity}
                       });
