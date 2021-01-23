    public class ProductsInfo
    {
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string medical_name { get; set; }
        public string slot_no { get; set; }
        public string num_of_units { get; set; }
        public string price { get; set; }
        public string expiry_date { get; set; }
        public string product_image { get; set; }
    }
    
    public class YourClass
    {
        public List<ProductsInfo> products_info { get; set; }
        public string response { get; set; }
    }
