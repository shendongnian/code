    public class LineItem
        {
            public int LineItemID { get; set; }
            public int QuantityOrdered { get; set; }
        }
    
        public class ReceivedLineItem : LineItem
        {
            public int QuantityReceived { get; set; }
        }
    
        // execution code somewhere..
            ...
            public List<ReceivedLineItem> Items { get; set; }
        
