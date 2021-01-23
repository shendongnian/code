    public class Product
    {
        public int ProductId;
        public string ProductDescription;
        public int StoreId;
        public int supplierid;
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return ProductId == ((Product)obj).ProductId;
        }
        public override int GetHashCode()
        {
            return ProductId.GetHashCode();
        }
    }
