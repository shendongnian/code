    public class ValidationError : BaseValidator
    {
        private ValidationError(string message)
            : base()
        {
            ErrorMessage = message;
            IsValid = false;
        }
    
        protected override bool EvaluateIsValid()
        {
            return false;
        }
    
        public static void DisplayError(string message, string validationGroup)
        {
            var currentPage = HttpContext.Current.Handler as Page;
            currentPage.Validators.Add(new ValidationError(message) { ValidationGroup = validationGroup });
        }
    }
