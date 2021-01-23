    [DelimitedRecord(",")]
    public class SomeRecord
    {
        public string Field1;
        [FieldConverter(typeof(CurrencyConverter))]
        public decimal Field2;
    }
