    public class UserReview
    {
        [Key, Column(Order = 0)]
        public string ReviewerId { get; set; } //The user that wrote the review
        [Key, Column(Order = 1)]
        public string ReviewedUserId { get; set; } //The user who was reviewed
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        public DateTimeOffset DateCreated { get; set; }
        [Required, ForeignKey("ReviewerId")]
        public virtual User Reviewer { get; set; }
        [Required, ForeignKey("ReviewedUserId")]
        public virtual User ReviewedUser { get; set; }
    }
    public class User
    {
        [Key]
        [Required]
        public string SubjectId { get; set; }
        public User()
        {                
            Reviews = new List<UserReview>();
        }
       
        [InverseProperty("ReviewedUser")] // or Reviewer.
        public virtual ICollection<UserReview> Reviews { get; set; }    
    }
