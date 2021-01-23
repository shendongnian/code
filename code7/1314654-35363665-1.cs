    public class VM_Student //Your Base
    {
      //Only include Attributes here that you need every time.
      public int Id { get; set; }
      [Required]
      [StringLength(50)]
      public string Name { get; set; }
        
    }
