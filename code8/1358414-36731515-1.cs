    public class ProductModel
    {
        public decimal NormalPrice { get; set:}
        public decimal DiscountPrice { get; set:}
        public bool NormalPriceGreaterThanDiscountPrice 
        { 
            get { return NormalPrice > DiscountPrice; } 
        }
    }
