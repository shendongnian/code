    public class Gauge
    {
        [Description("24 Gauge")]
        public const double G24 = 0.239;
        [Description("20 Gauge")]
        public const double G20 = 0.359;
        [Description("18 Gauge")]
        public const double G18 = 0.478;
        [Description("16 Gauge")]
        public const double G16 = 0.598;
        [Description("14 Gauge")]
        public const double G14 = 0.747;
        private double Value { get; set; }
        private Gauge(Double d)
        {
            Value = d;
        }
        public static implicit operator Double(Gauge g)
        {
            return g.Value;
        }
        public static implicit operator Gauge(Double d)
        {
            return new Gauge(d);
        }
    }
