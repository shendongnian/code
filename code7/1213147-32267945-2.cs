	public class QuestionModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [StringLength(250)]
        public string Question { get; set; }
        public virtual ICollection<QuestionTypeModel> QuestionTypes { get; set; }
    }
    public class QuestionTypeModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [StringLength(250)]
        public string TypeName { get; set; }
        public virtual ICollection<QuestionModel> Questions { get; set; }
    }
