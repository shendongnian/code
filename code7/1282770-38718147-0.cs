    public class PinnacleAccount
    {
      [Required]
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public Guid Id { get; set; }
    
      public virtual ApplicationUser User { get; set;  }
      [Required]
      public virtual string UserId { get; set; }  
    }
