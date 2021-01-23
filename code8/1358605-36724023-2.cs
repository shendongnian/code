    var badDate = new DateTime(1, 1, 1);
    return EdiReader.EdiReader.ReadEdiAndConvert(filePath)
        .Where(x => x.SiteNo == site)
        .Select(invoice => new DbBillInvoice() 
        {
            MeterNumber = invoice.MeterNumber,
            //assuming invoice.StartReadDate is actually a DateTime value, and not a string,
            // and that DbBillInvoice.StartReadDate is Nullable<DateTime>
            StartReadDate = (invoice.StartReadDate == badDate)?(DateTime?)null:invoice.StartReadDate,
            StartRead = invoice.StartRead,
            StartReadType = invoice.StartReadType,
            EndReadDate =  (invoice.EndReadDate == badDate)?(DateTime?)null:invoice.EndReadDate,
            EndRead = invoice.EndRead,
            EndReadType = invoice.EndReadType,
            ...
        }).ToList(); //Potential for a big performance win if you can change processing to avoid the ToList() call here.
