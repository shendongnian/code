    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        //Foreign key for User
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
