    public class QuestionQuestionTypesModel
    {
        [Key, Column(Order = 1), ForeignKey("Question")]
        public Guid QuestionID { get; set; }
        [Key, Column(Order = 2), ForeignKey("QuestionType")]
        public Guid QuestionTypeID { get; set; }
        public virtual QuestionModel Question { get; set; }
        public virtual QuestionTypeModel QuestionType { get; set; }
    }
