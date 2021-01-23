    [IgnoreFirst]
    [DelimitedRecord(",")]
    public class MyTypeObj
    {
        [FieldQuoted]
        [FieldConverter(ConverterKind.Int32)]
        public int ID;
        [FieldQuoted]
        [FieldConverter(ConverterKind.Date, "yyyy-mm-dd")]
        public DateTime EventDate;
        [FieldQuoted]
        public string IPAddress;
    }
