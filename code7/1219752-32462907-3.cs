    [IgnoreFirst]
    [DelimitedRecord(",")]
    public class MyTypeObj
    {
        [FieldQuoted]
        [FieldConverter(ConverterKind.Int32)]
        public int ID;
        [FieldQuoted]
        public string EventDate;
        [FieldQuoted]
        public string IPAddress;
    }
