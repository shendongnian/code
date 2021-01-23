    public class Banner
    {
        public Banner() //Add the default constructor and initiate the Country object
        {
            Country = new Country();
        }
        public int IdBanner { get; set; }
        public string NameBanner { get; set; }
        public string Media { get; set; }
    
        public Country Country{ get; set; }
    }
