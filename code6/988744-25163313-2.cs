    public class Business
    {
        public int BusinessID { get; set; }
        public string BusinessName { get; set; }
        public string BusinessWebsite { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessCity { get; set; }
        public string BusinessState { get; set; }
        public string BusinessZip { get; set; }
        public string BusinessDescription { get; set; }
        public int CategoryId { get; set; }
        
        public int SubCategoryId { get; set; }
        [Range(0.0, 5.0)]
        public int Rating { get; set; }
        public DateTime LastLogIn { get; set; }
        // Need to add more fields
    }
