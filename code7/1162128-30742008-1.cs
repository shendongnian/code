        public int GenerateInvoice(Invoice invoice)
        {
            using (DataContext dc = new DataContext())
            {
                dc.Invoices.Add(invoice);
                dc.SaveChanges();
            }
            return invoice.Id;
        }
        public bool GenerateInvoice(InvoiceVM invoice)
        {
            //create an Invoice record from the InvoiceVM
            Invoice inv = new Invoice();
            //handle other fields for invoice here  
            //create invoice, with no timesheets
            int invoiceId = manager.GenerateInvoice(inv);
            //loop through the timesheets and assign the invoice to them.
            using (DataContext dc = new DataContext())
            {
                foreach (var item in invoice.TimesheetList)
                {
                    TimeSheet ts = dc.GetTimesheetById(item.Id);
                    ts.InvoiceId = invoiceId;
                }
                dc.SaveChanges();
            }
            return true;
        }
