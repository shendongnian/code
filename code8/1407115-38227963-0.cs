    [DataContract]
    [KnownTypes(typeof(InvoiceDetail)]
    public class Invoice
    {
        [DataMember]
        public string SomeProperty {get; set; }
    }
    [DataContract]
    public class InvoiceDetail : Invoice
    {
    }
