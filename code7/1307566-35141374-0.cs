           abstract class Pagination<T>
        {
            public int _offset { get; set; }
            public int _total { get; set; }
            public string previous { get; set; }
            public string next { get; set; }
    public List<T> items { get; set; }
           
            public int getItemCount()
            {
                return items != null ? items.Count() : 0;
            }
           
        }
    
        class OrderHeader : Pagination<OrderLine>
        {
            public int orderId { get; set; }
            
        }
    
        class OrderLine : Pagination<OrderLineDetails>
        {
            public string sku { get; set; }
            public int qty { get; set; }
     
        }
  
