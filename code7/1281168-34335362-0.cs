    public class OrderItemDetail
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double DiscountAmount { get; set; }
        public double DiscountPerc { get; set; }
        public double TotalPrice { get; set; }
        public string Notes { get; set; }
    }    
    public class RootObject
    {
        public int EmpId { get; set; }
        public bool IsTakeAway { get; set; }
        public int NoOfPersons { get; set; }
        public int ResturantId { get; set; }
        public int StatusId { get; set; }
        public int TableId { get; set; }
        public List<OrderItemDetail> OrderItemDetails { get; set; }
    }
