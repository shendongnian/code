    public class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            return x != null && y != null &&
                   x.ProductId == y.ProductId &&
                   x.ProductDescription == y.ProductDescription &&
                   x.StoreId == y.StoreId;
        }
        public int GetHashCode(Product obj)
        {
            return String.Format("{0}-{1}-{2}",
                obj.ProductId,
                obj.ProductDescription,
                obj.StoreId)
                .GetHashCode();
        }
    }
