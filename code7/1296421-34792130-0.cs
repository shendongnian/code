    public void GetQuote(QuoteData data)
    {
        using (Database db = new Database())
        {
            var result = CalculateResult(db, data);
            byte[] pdfByte = (result.Data.PDF);
            var pdf = new PDF { PDFbyte = pdfByte, CustomerId = result.Data.CustomerId };
            db.PDF.Add(pdf);
            int rfqLast = (from x in db.Quote where x.MKCRFQ != null orderby x.Id descending select x.MKCRFQ).Take(1).SingleOrDefault();
            var rfqAdd = new Quote { MKCRFQ = rfqLast + 1 };
            result.Quote.MKCRFQ = rfqAdd.MKCRFQ;
            db.Quote.Add(result.Quote);
            db.SaveChanges();
        }
    }
