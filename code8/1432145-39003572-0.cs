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
    public class Root
    {
        public string accountId { get; set; }
        public string website { get; set; }
        public IList<AlternateWebsite> alternateWebsites { get; set; }
        public string email { get; set; }
        public IList<AlternateEmail> alternateEmails { get; set; }
        public Address address { get; set; }
        public IList<RankingKeyword> rankingKeywords { get; set; }
    }
