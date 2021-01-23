    public class WebListingVerification : IEqualityComparer<WeblistingVerification>
    {
        public string Sku { get; set; }
        public bool Equals(WebListingVerification obj, WebListingVerification obj2)
        {
            if (obj == null && obj2 == null)
                return true;
            else if (obj == null | obj2 == null)
                return false;
            else if (obj.Sku == obj2.Sku)
                return true;
            else
                return false;
        }
        public int GetHashCode(T obj)
        {
            return Sku.GetHashCode();
        }
    }
