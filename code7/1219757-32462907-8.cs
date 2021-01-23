    [IgnoreFirst]
    [DelimitedRecord(",")]
    public class MyTypeObj
    {
        [FieldConverter(ConverterKind.Int32)]
        public int ID;
        [FieldQuoted]
        [FieldConverter(ConverterKind.Date, "yyyy-mm-dd")]
        public DateTime EventDate;
        [FieldQuoted]
        public string IPAddress;
    }
