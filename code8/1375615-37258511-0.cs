    class Tax
    {
        public int Id { get; set; }
        [ForeignKey("Org")]
        public int OrgId { get; set; }
        [InverseProperty("Taxes")]
        public virtual Org Org { get; set; }
    }
