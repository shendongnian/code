    class RebateBase
    {
        public int ID { get; set; }
    
        public RebateType RebateType { get; set; }
    
        public virtual ICollection<Customer> Customers { get; set; }
        
        [InverseProperty("RebateBasesAvailable")]
        public virtual ICollection<TurnoverClassification> AvailableTurnoverClassifications { get; set; }
    
        [InverseProperty("RebateBasesEnabled")]
        public virtual ICollection<TurnoverClassification> EnabledTurnoverClassifications { get; set; }
    
    
        public RebateBase()
        {
            if (AvailableTurnoverClassifications == null)
            {
                AvailableTurnoverClassifications = new List<TurnoverClassification>();
            }
    
            if (EnabledTurnoverClassifications == null)
            {
                EnabledTurnoverClassifications = new List<TurnoverClassification>();
            }
    
            if (Customers == null)
            {
                Customers = new List<Customer>();
            }
        }
