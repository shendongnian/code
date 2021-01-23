    using System.ComponentModel.DataAnnotations.Schema;
    public class Customer
    {
      [DatabaseGenerated(DatabaseGeneratedOptions.None)]
      public Guid Id { get; set; }
      ..
    }
