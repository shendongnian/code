    public class LineItem
    {
        public string dealerProductCode { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
        public string amount { get; set; }
    }
    
    public class LineItemContainer
    {
     public List<LineItem> lineItem{get;set;}
    }
    
    public class Data
    {
      public LineItemContainer lineItems {get;set;}
    }
