    public class ApplicationUser : IdentityUser
    {
    [Key]
    ApplicationUserId { get; set; }
    [Required]
    [MaxLength(200)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(500)]
    public string LastName { get; set; }
    }
