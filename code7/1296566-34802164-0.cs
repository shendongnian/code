    public class QuestionnaireVM
    {
      public IEnumerable<QuestionGroupVM> Groups { get; set; }
      public SelectList Scores { get; set; }
    }
    public class QuestionGroupVM
    {
      public string Name { get; set; }
      public IEnumerable<QuestionVM> Questions { get; set; }
    }
    public class QuestionVM
    {
      public int ID { get; set; }
      public string Question { get; set; }
      public int Score { get; set; }
      public string Comments { get; set; }
    }
