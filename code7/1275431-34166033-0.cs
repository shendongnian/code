     public class PaymentCertificate : DBModelBase
     {
         public PaymentCertificate()
         {
             ValuationItems = new Collection();
         }
         public virtual ICollection ValuationItems { get; set; }
         [NotMapped]
         public decimal Total { get {return ValuationItems.Sum(v => v.ValuationQuantity * v.Cost.Price); }; private set;}
     }
