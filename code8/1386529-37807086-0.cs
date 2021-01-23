    [DelimitedRecord(",")]
    class Product : INotifyWrite // <-- implement events
    {
        [FieldQuoted(QuoteMode.AlwaysQuoted)]
        public string Name;
        [FieldQuoted(QuoteMode.AlwaysQuoted)]
        public string Description;
        [FieldQuoted(QuoteMode.AlwaysQuoted)]
        public string Size;
        public void BeforeWrite(BeforeWriteEventArgs e)
        {
        }
        public void AfterWrite(AfterWriteEventArgs e)
        {
            // replace any occurrences of ,"", with ,,
            e.RecordLine = e.RecordLine.Replace(",\"\",", ",,");
        }
    }
