    public class MeterReading : EntityBase
    {
        public long PropertyId { get; set; }
        public long? LastMeterReadingId { get; set; }
        public long? PaymentId { get; set; }
        public Property Property { get; set; }
        public MeterReading LastReading { get; set; }
        public Payment Payment { get; set; }
    }
