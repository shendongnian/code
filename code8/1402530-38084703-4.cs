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
    public class SessionQuestion
    {
      [Key]
      public int SessionQuestionId { get; set; }
      
      public int QuestionId{get;set;}
       
      ForeignKey(nameof(QuestionId))]
      public virtual Question Question{get;set;}
      
      public int PlayerAnswerId{get;set;}
    	
      ForeignKey(nameof(PlayerAnswerId))]
      public virtual Answer PlayerAnswer{get;set;}
      public int TriviaSessionId { get; set; }
      
      ForeignKey(nameof(TriviaSessionId))]
      public virtual TriviaSession TriviaSession{ get; set; }
    }
    
    public class TriviaSession
    {
      [Key]
      public int SessionId { get; set; }
      
      public int PlayerId { get; set; }
      
      ForeignKey(nameof(PlayerId))]
      public virtual Player Player{ get; set; }
      
      public virtual ICollection<SessionQuestion> SessionQuestions{get;set;}
    }
    
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
    
        public string Name { get; set; }
    	
    	public virtual ICollection<TriviaSession> TriviaSessions{get;set;}
    }
