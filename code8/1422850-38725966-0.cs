    public decimal  Value { get; set; }
    public byte     ValuePrecision { get; set; }
    
    public string FormatValue()
    {
        string fmtString = string.Format("{{0:N{0}}}", this.ValuePrecision);
        return string.Format(fmtString, this.Value);
    }
