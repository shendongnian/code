    public class LoginModel
    {
      public string Email { get; set; }
      public string Password { get; set; }
      public int Question1 { get; set; } // change
      public int Question2 { get; set; } // change
      public string Answer1 { get; set; } // change
      public string Answer2 { get; set; }
      public SelectList QuestionList { get; set; }
    }
