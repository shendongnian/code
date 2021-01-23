    public class TProduct
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public string ProductName { get; set; }
        public string WordName { get; set; }
        public string BrandName { get; set; }
        public string ProductNameClean { get; set; }  //interned field
        public string BrandNameClean { get; set; }    //interned field
    }
