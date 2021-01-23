    public class SubQuestionVM
    {
      public int ID { get; set; }
      public string Text { get; set; }
      public string Rating { get; set; }
    }
    public class QuestionVM
    {
      public int ID { get; set; }
      public string Text { get; set; }
      public List<SubQuestionVM> SubQuestions { get; set; }
    }
