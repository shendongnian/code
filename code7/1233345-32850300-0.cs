    /* BaseEntity just adds "Id" and some other properties common to all my
       POCOs */
    public class EntityHistory : BaseEntity
    {
      /* ... Other properties removed for clarity ... */
      public Guid TransactionId { get; set; }
      public DateTime TransactionTime { get; set; }
      public string OldValues { get; set; }
      public string NewValues { get; set; }
    }
