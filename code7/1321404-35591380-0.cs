    [DelimitedRecord("|")]
    public class Orders
    {
        public int OrderID;
    
        public string CustomerID;
    
        [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
        public DateTime OrderDate;
    
        [FieldConverter(ConverterKind.Decimal, ".")] // The decimal separator is .
        public decimal Freight;
    }
