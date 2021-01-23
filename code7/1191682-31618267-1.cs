    var entity = new CsvDbEntities1();
                foreach (var item in model)
                {
                    var tc = new TemporaryCsvUpload
                    {
                        PoNumber = item.Number,
                        CreditInvoiceAmount = item.CreditInvoiceAmount,
                        CreditInvoiceDate = item.CreditInvoiceDate,
                        CreditInvoiceNumber = item.CreditInvoiceNumber
                    };
                    entity.TemporaryCsvUploads.Add(tc);
                    var ptt = entity.PermanentTestTables.ToList().Where(x => x.Number == tc.Number);
                    foreach (var row in ptt)
                    {
                        row.CreditInvoiceDate = tc.CreditInvoiceDate;
                        row.CreditInvoiceNumber = tc.CreditInvoiceNumber;
                        row.CreditInvoiceAmount = tc.CreditInvoiceAmount;
                    }
                    entity.SaveChanges();
                }
