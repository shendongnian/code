    public class Order
    {
        private readonly List<OrderLine> _orderLines;
        
        public IEnumerable<OrderLine> OrderLines 
        {
            get { return _orderLines.AsReadonly(); }
        }
        
        public void RemoveOrderLine(Guid orderLineId)
        {
            //Remove logic
        }    
    }
