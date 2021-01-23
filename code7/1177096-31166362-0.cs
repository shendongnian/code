    public class QuizSubmission
    {
      public string QuizName { get;set; }
    
      public List<QuizQuestionResponse> Responses { get;set; }
    }
    
    public class QuizQuestionResponse
    {
       public int QuestionId { get;set; }
       public int AnswerId { get;set; }
    }
