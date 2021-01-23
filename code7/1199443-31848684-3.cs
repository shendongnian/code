    public PartialViewResult Invoices(int CompanyID, bool DisplayPaid)
    {
      // Get the filtered collection
      IEnumerable<Invoice> model = DbContext.Invoice.Where(....
      return PartialView("_Invoices", model);
    }
