    public  partial class Person
    {
        [Key]
        public int BusinessEntityID { get; set; }
        [Required]
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }
        [Column(TypeName = "xml")]
        public string AdditionalContactInfo { get; set; }
        [Column(TypeName = "xml")]
        public string Demographics { get; set; }
    }
