    public class AnnualInformation
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual decimal AnnualAmount { get; set; }
        public virtual string AnnualCurrency { get; set; }
        public virtual MonthlyInformation MonthlyInformation { get; set; }
        public virtual ShareValueInformation ShareValueInformation { get; set; }
        public virtual MiscDetails MiscDetails { get; set; }
    }
