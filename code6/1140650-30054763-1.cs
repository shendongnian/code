     public class ValidationResult
     {
        public bool IsValid { get; set; }
        public IList<string> Errors { get; set; }
        public ValidationResult()
        {
            Errors = new List<string>();
        }
     }
    public class IsValidInput
    {
        public ValidationResult IsValid(object value)
        {
            ValidationResult result = new ValidationResult();
            try
            {
                ExternalValidator.Validate(value);
                result.IsValid = true;
            }
            catch (CustomException ex)
            {
                foreach(var errorText in ex.GetDescriptions())
                {
                    result.Errors.Add(this.ErrorMessage + errorText);
                }
            }
        }
        return result;
    }
