    //I put all properties of your list to separate model
    public class AttriduteViewModel
    {
        public int ProductColorVariantId { get; set; }
        public int ProductSizeVariantId { get; set; }
        public int ProductSizeVariantValueId { get; set; }
        public int ProductAttributeId { get; set; }
        public int ProductAttributeValueId { get; set; }
    }
    
    public class ProductAttributesViewModel
    {
        public Product Product { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
        public ProductAttributeValue ProductAttributeValue { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string Sizes { get; set; }
        public int Stock { get; set; }
        //note this line
        public List<AttriduteViewModel> AdditionalAttridutes {get; set;}
    }
