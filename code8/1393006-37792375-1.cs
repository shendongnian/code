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
    
        [FieldConverter(ConverterKind.Decimal, ".")]
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public decimal Debet;
    
        [FieldConverter(ConverterKind.Decimal, ".")]
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public decimal Kredit;
    
        [FieldConverter(ConverterKind.Decimal, ".")]
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public decimal Saldo;
    }
