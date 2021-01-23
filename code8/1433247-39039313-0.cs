    [HttpPost]
    public PdfPrinterResponse Print()
    {
       var json = Request.Content.ReadAsByteArrayAsync().Result;
    
       Requeste1 request1;
       if(TrySerialzieTo<Request1>(json, out request1))
           // send request to wcf service
    
       Requeste2 request2;
       if(TrySerializeTo<Request2>(json, out requeste2))
           // send request to wcf service
    
    }
    private bool TrySerializeTo<T>(string json, out T request)
    {
         // use JsonConvert.Deserialize<T>(json);
         throw new NotImplementedException();
    }
