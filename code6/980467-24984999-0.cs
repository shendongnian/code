    public class OrderDetail
    {
        public string MessageTypeCode { get; set; }
        public string OrderDetailId { get; set; }
        public ClientInfo ClientInfo { get; set; }
        [XmlArray("OrderTaxes")]
        [XmlArrayItem("OrderTax")]
        public List<OrderTax> OrderTaxes { get; set; }
        [XmlArray("OrderTransactions")]
        [XmlArrayItem("OrderTransaction")]
        public List<OrderTransaction> OrderTransactions { get; set; }
    }
    public class OrderTransaction
    {
        public string LoanAmount { get; set; }
        public Title Title { get; set; }
    }
    public class Title
    {
        [XmlArray("TitleVendors")]
        [XmlArrayItem("TitleVendor")]
        public List<TitleVendor> TitleVendors { get; set; }
    }
    public class TitleVendor
    {
        public string VendorInstructions { get; set; }
        [XmlArray("VendorServices")]
        [XmlArrayItem("TitleVendorService")]
        public List<TitleVendorService> VendorServices { get; set; }
    }
    public class TitleVendorService
    {
        public string TitleVendorServiceId { get; set; }
        public string ServiceCode { get; set; }
        public string CustomVendorInstructions { get; set; }
    }
    public class ClientInfo
    {
        public string ClientName;
    }
    public class OrderTax
    {
        public string TaxId;
    }
