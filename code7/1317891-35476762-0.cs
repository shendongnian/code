    public class Price
    {
    public int PriceId {get; set;}
    [ForeignKey("ProductPurchase")]
    public int ProductId {get; set;}
    public Product ProductPurchase {get; set;}
    [ForeignKey("ProductRetail")]
    public int ProductRetailId {get; set;}
    public Product ProductRetail {get; set;}
    public DateTime ActivationDate {get; set;}
    public decimal value {get; set;}
    }
