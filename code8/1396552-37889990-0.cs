    public class Fund
    {
        [Key]
        public string FundCode {get; set;}
    
        public virtual RedemptionFee RedemptionFee {get; set;}
    }
    
    public class RedemptionFee
    {
        [Key]
        [ForeignKey("Fund")]
        public string FundCode {get; set;}
        public virtual Fund Fund {get; set;}
    }
