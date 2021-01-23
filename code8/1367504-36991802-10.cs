    public DoubleHelper(double d)
    {
        this.RawBits = (ulong)BitConverter.DoubleToInt64Bits(d);
    }
    public ulong RawBits { get; }
    // RawSign is 1 if zero or negative, 0 if zero or positive
    public int RawSign => (int)(RawBits >> 63);
    public int RawExponent => (int)(RawBits >> 52) & 0x7FF;
    public long RawMantissa => (long)(RawBits & 0x000FFFFFFFFFFFFF);
    public bool IsNaN => RawExponent == 0x7ff && RawMantissa != 0;
    public bool IsInfinity => RawExponent == 0x7ff && RawMantissa == 0;
    public bool IsZero => RawExponent == 0 && RawMantissa == 0;
    public bool IsDenormal => RawExponent == 0 && RawMantissa != 0;
