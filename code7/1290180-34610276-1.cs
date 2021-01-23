    public class IntValue: Value, IValue<int>
    {
        public int Data { get; set; }
        protected override string AsFormattedString() { return Data.ToString(FormatString); }
        public IntValue() { FormatString = "{0:#,##0;-#,##0;'---'}"; }
        public IntValue(string formatstring, int data) { FormatString = formatstring; Data = data; }
    }
    public class DoubleValue: Value, IValue<double>
    {
        public double Data { get; set; }
        protected override string AsFormattedString() { return Data.ToString(FormatString); }
        public DoubleValue() { FormatString = "{0:0.#0;-0.#0;'---'}"; }
        public DoubleValue(string formatstring, double data) { FormatString = formatstring; Data = data; }
    }
