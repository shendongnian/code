    private class ProductList
    {
        public string productSku { get; set; }
        public string productName { get; set; }
        public string productSubfamilyId { get; set; }
        public string productSubfamilyName { get; set; }
        public string productFamilyId { get; set; }
        public string productFamilyName { get; set; }
        
        public override bool Equals(object otherProduct)
        {
            //your code goes here to tell when the 2 products are equivalent.
        }
        public override int GetHashCode()
        {
             //return your hash code
        }
    };
