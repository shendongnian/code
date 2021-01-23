    public interface IValidatorCommand
    {
        object Input { get; set; }
        CustomValidationResult Execute();
    }
    public class CustomValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
