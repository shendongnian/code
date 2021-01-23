    public ActionResult Invoice(int id)
    {
         InvoiceViewModel viewModel = new InvoiceViewModel();
         viewModel.Header = db.InvoiceHead.SingleOrDefault(i => i.ID == id);
         if(viewModel.Header != null)
         {
             viewModel.Details = db.Details.Where(d => d.Inv_id == id).ToList();
         }
         return View(viewModel);
    }
