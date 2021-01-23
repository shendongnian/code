    class Program
        {
        static void Main(string[] args)
        {
            var products = new List<Products>();
            var offers = new List<Offers>();
            products.All(t => t.ProductOffers.All(s => s.SetSubscription(offers.First(r => r.OfferId == s.ProductOfferId))));
        }
    }
    public class Products
    {
        public List<ProductOffers> ProductOffers { get; set; }
    }
    public class ProductOffers
    {
        public string ProductOfferId { get; set; }
        public string ProductSubscription { get; set; }
        public bool SetSubscription(Offers offerDets)
        {
            if (offerDets != null)
            {
                this.ProductSubscription = offerDets.subscription;
                return true;
            }
            return false;
        }
    }
    public class Offers
    {
        public string OfferId { get; set; }
        public string subscription { get; set; }
    }
