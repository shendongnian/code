    class Transaction
    {
        [Key]
        [Column(Order = 1)]
        public string RegistrantId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string RecipientId { get; set; }
        [ForeignKey(Name = "RegistrantId")]
        public virtual Employee Registrant { get; set; }
        [ForeignKey(Name = "RecipientId")]
        public virtual Employee Recipient { get; set; }
    }
