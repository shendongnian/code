    public class SponsorInfo
    {
        public decimal SponsorID { get; set; }
        public decimal FirstBAID { get; set; }
        public decimal SecondBAID { get; set; }
        public decimal ThirdBAID { get; set; }
    }
    public class SponsorInfoList
    {
        public Dictionary<string, SponsorInfo> SIList { set; get; }
    }
