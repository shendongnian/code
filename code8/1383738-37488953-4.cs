    [FixedLengthRecord(FixedMode.AllowLessChars)]
    [IgnoreEmptyLines]
    class VWDischargeTXT
    {
        [FieldFixedLength(14)]
        public long AcctNum;
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Right)]
        public string province;
        [FieldFixedLength(137)]
        [FieldTrim(TrimMode.Right)]
        public string CustomerName;
        [FieldFixedLength(26)]
        [FieldTrim(TrimMode.Right)]
        public string VIN;
        [FieldFixedLength(51)]
        [FieldTrim(TrimMode.Right)]
        public string RegNo;
        [FieldFixedLength(31)]
        [FieldTrim(TrimMode.Right)]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime DischargeDate;
    }
