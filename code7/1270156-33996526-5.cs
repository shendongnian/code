    public void CalculateRates(TruckDb db, QuoteData data, out QuoteResult qrResult)
    {
        qrResult= new QuoteResult
        {
            Successful = false,
            Data = data
        };    
        
        //...unnecessary to see codes and calculations...
    
        qrResult.QuoteItem = quoteItem;
        qrResult.Successful = true;        
    }
