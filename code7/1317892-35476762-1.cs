    public class Price
    {
       public int PriceId {get; set;}
       public int ProductPurchaseId {get; set;}
       public Product ProductPurchase {get; set;}
       public int ProductRetailId {get; set;}
       public Product ProductRetail {get; set;}
       public DateTime ActivationDate {get; set;}
       public decimal value {get; set;}
    }
