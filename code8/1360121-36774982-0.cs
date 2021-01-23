     public class ProductDTO
     {
        [DataMember]
        public Guid ProductId {get; set;}
        [DataMember]
        public virtual IEnumerable<DateTime> TransactionDates { get; set; }
     }
