    [IgnoreFirst]
    [DelimitedRecord(",")]
    public class MyObject
    {
        [FieldQuoted]
        [FieldConverter(ConverterKind.Int32)]
        public int ID;
        [FieldQuoted]
        public DateTime EventDate;
        [FieldQuoted]
        public string IPAddress;
    }
