    public class ApplicationUser : IdentityUser
    {
    [Key]
    public int ApplicationUserId { get; set; }
    [Required]
    [MaxLength(200)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(500)]
    public string LastName { get; set; }
    }
