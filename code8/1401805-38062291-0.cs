    public class Invoice
    {
    	public string Description { get; set; }
    	public string InvoiceTypeId { get; set; }
    	public string CustomerAccountsId { get; set; }
    	public string InvoiceDate { get; set; }
    	public string PayableDate { get; set; }
    	public string Prefix { get; set; }
    	public string Serial { get; set; }
    	public string tag { get; set; }
    }
    
    public class InvoiceLine
    {
    	public string ValueId { get; set; }
    	public string Qantity { get; set; }
    	public string UnitId { get; set; }
    	public string Price { get; set; }
    	public string VatRateId { get; set; }
    	public string LineVat { get; set; }
    	public string LineTotal { get; set; }
    	public string Vat { get; set; }
    }
    
    public class Invoices
    {
    	public Invoice Invoice { get; set; }
    	public List<InvoiceLine> InvoiceLine { get; set; }
    }
