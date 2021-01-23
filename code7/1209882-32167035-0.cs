    public class QuestionVM
    {
      public int ID { get; set; }
      public string Question { get; set; }
      [Required(ErrorMessage = "Please enter and answer")]
      public string Answer { get; set; }
      public string Document { get; set; }
    }
