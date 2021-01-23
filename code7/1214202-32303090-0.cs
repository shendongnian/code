    public class NoDuplicateEmail : ValidationAttribute
    {
      private const string _DefaultErrorMessage = "Email {0} is in use!"
      public NoDuplicateEmail() : : base(_DefaultErrorMessage)
      {
      }
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
        var context = new MhotivoContext();
        if (value != null)
        {
          var email = (string)value;
          if(context.Users.FirstOrDefault(x => x.Email == emailValue) != null)
          {
            return new ValidationResult(FormatErrorMessage(email));
          }
        }
        return ValidationResult.Success;
      }
    }
