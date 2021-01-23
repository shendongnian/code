    public class Product 
    {
        [Key]
        public int Id { get; set; }
        public string SKU_Code { get; set; }
        public string Product_Name { get; set; }        
        public string Price { get; set; }
        public string Image { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
    }
    
    public class Order
    {
        [Key]
        public long ID { get; set; }
        public string Order_Id { get; set; }
        public string Payment_Type { get; set; }
        public string Customer_Name { get; set; }
        public string Shipping_Address { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Modified_Date { get; set; }
        public bool Flag { get; set; }
        public List<OrderLineItem> Items { get; set; }
    }
        
    public class OrderLineItem
    {
        [Key]
        public long ID { get; set; }
        public long Order_Id { get; set; }
        public long Product_Id {get; set;}
        public int Quantity {get; set;}
    }
