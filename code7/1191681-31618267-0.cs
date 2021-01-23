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
                    entity.SaveChanges();
                    var ptt = entity.PermanentTestTables.ToList().Where(x => x.Number == tc.Number);
                    foreach (var number in ptt)
                    {
                        number.CreditInvoiceDate = tc.CreditInvoiceDate;
                        number.CreditInvoiceNumber = tc.CreditInvoiceNumber;
                        number.CreditInvoiceAmount = tc.CreditInvoiceAmount;
                    }
                    entity.SaveChanges();
                }
