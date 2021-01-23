    var badDate = new DateTime(1, 1, 1);
    return EdiReader.EdiReader.ReadEdiAndConvert(filePath)
        .Where(x => x.SiteNo == site)
        .Select(invoice => new DbBillInvoice() 
        {
            MeterNumber = invoice.MeterNumber,
            //assuming this is actually a DateTime value, and not a string
            StartReadDate = (invoice.StartReadDate == badDate)?null:invoice.StartReadDate,
            StartRead = invoice.StartRead,
            StartReadType = invoice.StartReadType,
            EndReadDate =  (invoice.EndReadDate == badDate)?null:invoice.EndReadDate,
            EndRead = invoice.EndRead,
            EndReadType = invoice.EndReadType,
            ...
        }).ToList(); //Potential for a big performance win if you can change processing to avoid the ToList() call here.
