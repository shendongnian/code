    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Summary { get; set; }
        [MaxLength(500)]
        public string Examples { get; set; }
        // As you said "A product has a group of questions (QuestionGroup)"
        // This can be omitted
        //public virtual QuestionGroup QuestionGroup { get; set; }
        public virtual ICollection<QuestionGroup> QuestionGroups { get; set; }
    }
    public class QuestionGroup
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Question> Questions { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        // As you said "can belong to multiple Questionaires"
        // This can be omitted
        public virtual ICollection<Questionaire> Questionaires { get; set; }
    }
    public class Questionaire
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Group")]
        public int QuestionGroupId { get; set; }
        public QuestionGroup Group { get; set; }
        [ForeignKey("Order")]
        public int QuestionOrderId { get; set; }
        public QuestionOrder Order { get; set; }
    }
