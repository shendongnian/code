    public class PremiumAdjustmentFinalisedEvent : IPremiumAdjustmentFinalised
    {
        public string PolicyNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime FinalisedOn { get; set; }
    }
