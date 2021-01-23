    public class SurveyVM
    {
      public List<CategoryVM> Categories { get; set; }
      // add any other properties of Survey you need to display/edit (e.g. ID, Title etc)
    }
    public class CategoryVM
    {
      public List<QuestionVM> Questions { get; set; }
      // add any other properties of Category you need to display/edit (e.g. ID, Title etc)
    }
    public class QuestionVM
    {
      public int Id { get; set; }
      public string Title { get; set; }
      public int Score { get; set; }
      // Do not include properties such as DateCreated, User etc
    }
