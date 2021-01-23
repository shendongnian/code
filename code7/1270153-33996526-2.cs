    public void CalculateRates(TruckDb db, QuoteData data, out QuoteResult qrResult)
    {
        qrResult= new QuoteResult
        {
            Successful = false,
            Data = data
        };
    
        List<QuoteItemSectionGroup> quoteItems = new List<QuoteItemSectionGroup>();
    
        var quoteItem = new QuoteItem
        {
            ChassisModel = db.ChassisModel.Find(data.ChassisId),
            ChassisManufacturer = db.ChassisManufacturer.Find(data.ChassisManufacturerId),
            BodyType = db.BodyTypes.Find(data.BodyTypeId),
            //...10 lines more
        };
    
        //...unnecessary to see codes and calculations...
    
        qrResult.QuoteItem = quoteItem;
        qrResult.Successful = true;        
    }
