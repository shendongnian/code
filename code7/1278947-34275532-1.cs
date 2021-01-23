    public class LoginViewModel
    {
      [RegularExpression("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;\s]+\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*){0,7}", ErrorMessage = "Please enter a valid email address.  For multiple addresses please use a comma or semicolon to separate the email addresses.")]
      public string EmailAddresses { get; set; }
    }
