     public class ValidationResult
     {
        public bool IsValid { get; set; }
        public IList<string> Errors { get; set; }
     }
    public class IsValidInput
    {
        public ValidationResult IsValid(object value)
        {
            try
            {
                ExternalValidator.Validate(value);
            }
            catch (CustomException ex)
            {
                foreach(var errorText in ex.GetDescriptions())
                {
                    this.ErrorMessage = this.ErrorMessage + errorText;
                }
            return false;
        }
        return true;
    }
