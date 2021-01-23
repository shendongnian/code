    public class OfferVM
    {
        public int ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:P0}")]
        public float Offer { get; set; } // assumes you store this as float in the db
    }
    public class ServiceVM
    {
        public string Name { get; set; }
        public IEnumerable<OfferVM> Offers { get; set; }
    }
