    foreach (var item in model)
            {
                var tc = new TemporaryCsvUpload();
                tc.Number = item.Number;
                tc.CreditInvoiceAmount = item.CreditInvoiceAmount;
                tc.CreditInvoiceDate = item.CreditInvoiceDate;
                tc.CreditInvoiceNumber = item.CreditInvoiceNumber;
                entity.TemporaryCsvUploads.Add(tc);
                entity.SaveChanges();
            }
