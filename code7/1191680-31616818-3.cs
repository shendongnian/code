    var entity = new CsvDbEntities1();
            foreach (var item in model)
            {
                var tc = new TemporaryCsvUpload();
                tc.Number = item.Number;
                tc.CreditInvoiceAmount = item.CreditInvoiceAmount;
                tc.CreditInvoiceDate = item.CreditInvoiceDate;
                tc.CreditInvoiceNumber = item.CreditInvoiceNumber;
                entity.TemporaryCsvUploads.Add(tc);
                entity.SaveChanges();
                var table2entity = entity.PermanentTestTable.ToList();
                table2entity = table2entity.Where(x => x.Number == tc.Number).Select(x => x).First();
                table2entity.CreditInvoiceAmount = item.CreditInvoiceAmount;
                //More values inserted here
                entity.SaveChanges()
            }
