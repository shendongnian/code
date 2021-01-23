    [XmlRoot("Invoices")]
    public class InvoiceList
    {
        [XmlElement("Invoice")]
        public List<Invoice> Invoices { get; set; }
    }
