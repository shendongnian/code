    'public class Company
    {
        [Key]
        [Required]
        public long CompanyCode { get; set; }
    
        [Required]
        public string CompanyName { get; set; }
        ...
    }'
     public class CompanyCurrency
        {
            [Key]
            public long RecordNo { get; set; }
            public long CompanyCode { get; set; }      //I have made it FK in db
            public virtual Company Company { get; set; }
    
    
            [Required]
            [StringLength(3)]
            [RegularExpression("^[A-Z]{3,3}$")]
            public string CurrencyCode { get; set; }   //and this one also
    
            public bool IsDefault { get; set; }
        }
