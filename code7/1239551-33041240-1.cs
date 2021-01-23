    public class ContactInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ContactInfoId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public virtual ICollection<ContactInfo> ContactInfoes { get; set; }
        public virtual ICollection<ProductQuestionaireReport> Reports { get; set; }
    }
    public class ProductQuestionaireReport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProductQuestionaireReportId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual QuestionaireResult Result { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public bool Haste { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
    }
    public class QuestionaireResult
    {
        [Key]
        public int ProductQuestionaireReportId { get; set; }
        [ForeignKey("Questionaire")]
        public int QuestionaireId { get; set; }
        public virtual Questionaire Questionaire { get; set; }
        public DateTime SurveyCreated { get; set; }
        public Double Costs { get; set; }
        public Double FunctionPoints { get; set; }
        public virtual ICollection<QuestionaireAnswer> Answers { get; set; }
    }
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Examples { get; set; }
        public virtual ICollection<Questionaire> Questionaires { get; set; }
        public virtual ICollection<ProductQuestionaireReport> Reports { get; set; }
    }
    public class QuestionaireAnswer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QuestionaireAnswerId { get; set; }
        [ForeignKey("QuestionaireResult")]
        public int QuestionaireResultId { get; set; }
        public virtual QuestionaireResult QuestionaireResult { get; set; }
        [ForeignKey("QuestionaireQuestion")]
        public int QuestionaireId { get; set; }
        public virtual QuestionaireQuestion QuestionaireQuestion { get; set; }
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public virtual QuestionOption Answer { get; set; }
        public virtual ICollection<string> Files { get; set; }
    }
    public class Questionaire
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QuestionaireId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<QuestionaireQuestion> QuestionaireQuestions { get; set; }
        public virtual ICollection<QuestionaireResult> Results { get; set; }
    }
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QuestionId { get; set; }
        [ForeignKey("ParentQuestion")]
        public int ParentQuestionId { get; set; }
        public virtual Question ParentQuestion { get; set; }
        [ForeignKey("CorrectOption")]
        public int? CorrectOptionId { get; set; }
        public virtual QuestionOption CorrectOption { get; set; }
        public virtual QuestionType QuestionType { get; set; }
        public virtual ICollection<QuestionOption> Options { get; set; }
    }
    public class QuestionType
    {
        [Key]
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsOpenQuestion { get; set; }
    }
    public class QuestionOption
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QuestionAnswerOptionId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public virtual Question Question { get; set; }
    }
    public class QuestionaireQuestion
    {
        [Key]
        public int QuestionaireId { get; set; }
        public virtual Questionaire Questionaire { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Question Question { get; set; }
    }
