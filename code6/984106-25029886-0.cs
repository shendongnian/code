    [Table("Completion")]
    public class CompletionsModel
    {
        [Column(Order = 0), Key]
        public int UserId { get; set; }
        [Column(Order = 1), Key]
        public string PRD_NUM { get; set; }
        public DateTime CompletionDate { get; set; }
        public virtual CourseModel PRD { get; set; }
        public virtual StudentModel UserProfile { get; set; }
    }
