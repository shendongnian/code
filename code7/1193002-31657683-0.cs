    public class User : IdentityUser
    {
      [MaxLength(50)]
      [Required]
      public string MyAdditionalData { get; set; }
      [Required]
      public int Age { get; set; }
    }
