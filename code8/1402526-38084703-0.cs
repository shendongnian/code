    public class Answer
    {
      [Key]
      public int AnswerId { get; set; }
      public string TextOfTheAnswer { get; set; }
		
	  public int QuestionId{get;set;}
	
	  ForeignKey(nameof(QuestionId))]
	  public virtual Question Question{get;set;}
    }
    public class Question
    {
      [Key]
      public int QuestionId { get; set; }
      public string TextOfTheQuestion { get; set; }
	
	  public virtual ICollection<Answer> Answers{get;set;}
      public int CorrectAnswerId{get;set;}
	
	  ForeignKey(nameof(CorrectAnswerId))]
	  public virtual Answer CorrectAnswer{get;set;}
    }
