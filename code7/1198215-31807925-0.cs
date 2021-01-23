    public class IndividualProductVm
    {
        public virtual Products Products { get; set; }
        public ProductSummary ProductSummary { get; set; }
        public virtual List<ProductSvhcSimpleResponse> ProductSimpleResponse { get; set; }
    }
