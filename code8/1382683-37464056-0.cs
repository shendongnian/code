    public class DcStatus
    {
        [Format("{0:0.0} V")]
        public Double Voltage { get; set; }
        [Format("{0:0.000} A")]
        public Double Current { get; set; }
        [Format("{0:0} W")]
        public Double Power => Voltage * Current;
        public string ToJson()
        {
            return new Dictionary<string,string>
            {
                { "Voltage", "{0:0.0} V".Fmt(Voltage) },
                { "Current", "{0:0.000} A".Fmt(Current) },
                { "Power", "{0:0} W".Fmt(Power) },
            }.ToJson();
        }
    }
