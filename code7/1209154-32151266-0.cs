    public class Fund
    {
        [Key]
        public int FundId { get; set; }
        [Required]
        [Index("IX_FundNameAndOwner", IsUnique = true, Order = 1)]
        [Index("IX_FundIdentifierAndOwner", IsUnique = true, Order = 1)]
        public int OwnerId { get; set; } // <---- ADD THIS!
        public virtual ApplicationUser Owner { get; set; }
        [Required]
        [Index("IX_FundNameAndOwner", IsUnique = true, Order = 2)]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [Index("IX_FundIdentifierAndOwner", IsUnique = true, Order = 2)]
        [MaxLength(25)]
        public string Identifier { get; set; }
        public double Balance { get; set; }
    }
