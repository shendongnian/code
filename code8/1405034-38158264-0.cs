    public class Authority
    {
        public long ID { get; set; }
        public string Term { get; set; }
        public string Language { get; set; }
        public bool PreferredTerm  { get; set; }
        public TermStatus TermStatus { get; set; }
        //Establish 1-to-0/1 self-referencing key
        [Column("Use")]
        public long? UseID { get; set; }
        [ForeignKey("UseID")]
        public List<Authority> Use { get; set; }
        //Establis 1-many foreign keys
        [ForeignKey("UsedFor")]
        public List<AuthorityList> UsedFor { get; set; }
        [ForeignKey("Equivalent")]
        public List<AuthorityList> Equivalent { get; set; }
        [ForeignKey("Broader")]
        public List<AuthorityList> Broader { get; set; }
        [ForeignKey("Narrower")]
        public List<AuthorityList> Narrower { get; set; }
    }
    public class AuthorityList
    {
        public long ID { get; set; }
        public long AuthorityID { get; set; }
        public long? UsedFor { get; set; }
        public long? Equivalent { get; set; }
        public long? Broader { get; set; }
        public long? Narrower { get; set; }
    }
