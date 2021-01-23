    [DelimitedRecord(",")]
    public class ImporBii
    {
        public long RekNum;
    
        public string Currency;
    
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime TransDate;
    
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime RecordDate;
    
        public string Unused1;
    
        public int TransCode;
    
        public string TransCodeStr;
    
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Keterangan;
    
        [FieldConverter(ConverterKind.Decimal, "#,##0.00")]
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Debet;
    
        [FieldConverter(ConverterKind.Decimal, "#,##0.00")]
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Kredit;
    
        [FieldConverter(ConverterKind.Decimal, "#,##0.00")]
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Saldo;
    }
