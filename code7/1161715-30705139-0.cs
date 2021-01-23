    [FluentValidation.Attributes.Validator(typeof(CustomValidator))]
    public UserViewModel
    {
      public bool IsBlue { get; set; }
      public bool IsRed { get; set; }
    }
    public class CustomValidator : AbstractValidator<UserViewModel>
    {
       public CustomValidator()
       {
        RuleFor(x => x.IsBlue).NotEqual(false)
            .When(t => t.IsRed.Equals(false))
            .WithMessage("You need to select one");
       }
     }
