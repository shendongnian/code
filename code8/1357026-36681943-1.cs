    using (Entities dc = new Entities())
    {
      var Invoice = dc.Invoices.First(p => p.ID == _InvoiceID);
      dc.InvoiceDetails.DeleteAllOnSubmit(Invoice.InvoiceDetails);
      foreach (DataGridViewRow item in DataGridView1.Rows)
      {
         Invoice.InvoiceDetails.Add(new InvoiceDetail
         {
             Description = "Description",
             TotalPrice = "10000000"
         });
    
      }
      dc.SubmitChanges();
    }
