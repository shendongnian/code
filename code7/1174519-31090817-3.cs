    class TurnoverClassification
    {
        public string Name { get; set; }
    
        public virtual ICollection<RebateBase> RebateBasesAvailable{ get; set; }
        public virtual ICollection<RebateBase> RebateBasesEnabled{ get; set; }
    
        [Key]
        public int NumericalValue { get; set; }
    }
