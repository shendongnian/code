    public class Orders
    {
        public int OrderId { get; set; }
    
        private List<OrderLine> oLines;
        public List<OrderLine> OLines
        {
            get
            {
                if (oLines == null)
                    oLines = new List<OrderLine>();
                return oLines;
            }
        }
    }
    
    public class OrderLine
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
