    public class AgreementCourse
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Agreement")]
        public int AgreementId { get; set; }
        public virtual Agreement Agreement { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public CourseTypeEnum CourseType { get; set; }
    }
