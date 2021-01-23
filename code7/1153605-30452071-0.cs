    [XmlRoot("Data")]
    public class Data
    {
        [XmlElement("Msg")]
        public Msg Msgs { get; set; }
    }
    public class Msg
    {
        [XmlElement]
        public string Type { get; set; }
        [XmlElement]
        public string UserID { get; set; }
        [XmlElement]
        public string SerialNumber { get; set; }
        [XmlElement]
        public string DateTime { get; set; }
        [XmlElement("Rows")]
        public Rows RowsObj { get; set; }
    }
    public class Rows
    {
        [XmlElement("Row")]
        public List<Row> RowsList { get; set; }
    }
    public class Row
    {
        [XmlElement]
        public string InvoiceCode { get; set; }
        [XmlElement]
        public string ServiceCode { get; set; }
        [XmlElement]
        public string BranchID { get; set; }
        [XmlElement]
        public string AbonCode { get; set; }
        [XmlElement]
        public string Amount { get; set; }
        [XmlElement]
        public string PaymentDate { get; set; }
        [XmlElement]
        public string ReceiptNumber { get; set; }
        [XmlElement]
        public string PaymentSite { get; set; }
        [XmlElement]
        public string PaymentInstrument { get; set; }
        [XmlElement]
        public string BankHeadOfficeCode { get; set; }
    }
