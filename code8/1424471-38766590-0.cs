    public class InvoiceAndItemsDTO
    {
        // Invoice
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        // Track
        public int InvoiceLineId { get; set; }
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public string Artist { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
