    public class customer
    {
        public int customerid { get; set; }
        public string customername { get; set; }
        public customerdetail[] detaile { get; set; }
    }
    
    public class customerdetail
    {
        public int customerid { get; set; }
        public int productid { get; set; }
        public string product { get; set; }
        public string desc { get; set; }
        public int quantity { get; set; }
        public int subtotal { get; set; }
    }
