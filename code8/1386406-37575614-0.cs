    public class ResponseModel
    {
        public bool Success {get;set;}
        ....
    
        public List<Quote> Quotes {get;set;}
    }
    
    public class QuoteModel
    {
        public decimal USDTWD {get;set;}
    }
