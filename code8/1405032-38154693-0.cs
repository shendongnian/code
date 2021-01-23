    public class Authority
    {
        [Key()]
        public long ID { get; set; }
        public string Term { get; set; }
        public string Language { get; set; }
        public bool PreferredTerm  { get; set; }
        public TermStatus TermStatus { get; set; }
        public Authority Use { get; set; }
        
        [Required]
        public long Authority_ID { get; set; }
        
        [Required]
        public long Authority_ID1 { get; set; }
        
        [Required]
        public long Authority_ID2 { get; set; }
        
        [Required]
        public long Authority_ID3 { get; set; }
        
        [ForeignKey("Authority_ID")]
        public ICollection<Authority> UsedFor { get; set; }
        
        [ForeignKey("Authority_ID1")]
        public ICollection<Authority> Equivalent { get; set; }
        
        [ForeignKey("Authority_ID2")]
        public ICollection<Authority> Broader { get; set; }
        
        [ForeignKey("Authority_ID3")]
        public ICollection<Authority> Narrower { get; set; }
    }
