    public class CCourseDetailModel
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] don't need this, it's the configuration by default.
        public int CourseDetailId { get; set; }
    
        public virtual CACourseOutcomesModel CourseOutcomes { get; set; }
    }
    
    public class CACourseOutcomesModel
    {
        [Key, ForeignKey("CourseDetail")]
        public int CourseOutcomesId { get; set; }
    
        public virtual CCourseDetailModel CourseDetail { get; set; }
    }
