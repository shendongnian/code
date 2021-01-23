    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            // TODO - Add null handling.
            return x.ProductCode == y.ProductCode;
        }
        public int GetHashCode(Product obj)
        {
            return obj.ProductCode.GetHashCode();
        }
    }
