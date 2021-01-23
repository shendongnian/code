    public class topProduct
    {
        public int quantity { get; set; }
        public string Name { get; set; }
        //default constructor
        public topProduct() {}
    
        public topProduct(string productDesc, int downloadCount)
        {
            this.Name = productDesc;
            this.quantity = downloadCount;
        }
    }
