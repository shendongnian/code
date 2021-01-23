    public class OfferDTO
    {
        public int OfferID { get; set; }
        public string Reference { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> FileNames { get; set; }
    }
