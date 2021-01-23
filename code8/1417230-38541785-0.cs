    public class ProductLog
    {
        public ProductTestInformation productTestInformation { get; set; }
        public int? ProductId { get { return productTestInformation .ProductId; } set { productTestInformation .ProductId = value; } }
        public string ProductName { get { return productTestInformation .ProductName; } set { productTestInformation .ProductName = value; } }
        public ProductLog()
        {
            this.productTestInformation = new ProductTestInformation();
        }
    }
