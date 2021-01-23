    public class AlternateWebsite
        {
            public string website { get; set; }
        }
    
    public class AlternateEmail
    {
        public string email { get; set; }
    }
    
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string state { get; set; }
    }
    
    public class RankingKeyword
    {
        public string keyword { get; set; }
        public string localArea { get; set; }
    }
    
    
    
    public class RootObject
    {
        public string accountId { get; set; }
        public string website { get; set; }
        public List<AlternateWebsite> alternateWebsites { get; set; }
        public string email { get; set; }
        public List<AlternateEmail> alternateEmails { get; set; }
        public Address address { get; set; }
        public List<RankingKeyword> rankingKeywords { get; set; }
    }
