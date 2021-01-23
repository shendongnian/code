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
            //Here I assume that your 2 products are equal when all the properties are equal:
            if (otherProduct == null)
               return false;
            return this.productSku == otherProduct.productSku &&
                   this.productName == otherProduct.productName &&
                   this.productSubfamilyId == otherProduct.productSubfamilyId &&
                   this.productSubfamilyName == otherProduct.productSubfamilyName &&
                   this.productFamilyId == otherProduct.productFamilyId &&
                   this.productFamilyName == otherProduct.productFamilyName;
        }
        public override int GetHashCode()
        {
             //return your hash code
        }
    };
