    public class Company
    {
        [Key]
        public int Id { get; set; }
    
        [InverseProperty("Supplier ")]
        public virtual ICollection<TradingRelationship> TradingRelationshipsSupplier  { get; set; }
    
        [InverseProperty("Buyer ")]
        public virtual ICollection<TradingRelationship> TradingRelationshipsBuyer  { get; set; }
    }
