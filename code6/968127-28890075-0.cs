    public virtual ActionResult PrintInvoice(int id) {
            var invoice = db.Invoices.Single(i => i.InvoiceId == id);
            var viewmodel = Mapper.Map<InvoiceViewModel>(invoice);
            var reportName = string.Format(@"Invoice {0:I-000000}.pdf", invoice.InvoiceNo);
            var switches = String.Format(@" --print-media-type --username {0} --password {1} ", 
                    ConfigurationManager.AppSettings["PdfUserName"],
                    ConfigurationManager.AppSettings["PdfPassword"]); 
            ViewBag.isPDF = true;
            return new ViewAsPdf("InvoiceDetails", viewmodel) {
                FileName = reportName,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
                PageSize = Rotativa.Options.Size.A4,
                CustomSwitches = switches
            };
        }
