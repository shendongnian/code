    public class QuestionViewModel
    {
      public int Id {set;get;}
      public string QuestionText { set;get;}
      public List<Answer> OffererdAnswers {set;get;}
    }
    public class Answer
    {
      public int Id {set;get;}
      public string AnswerText {set;get;}
      public bool IsSelected { set;get;}
    }
