    public class CustomValidator
    {
        public static ValidationResult IsNumberValid(int number, ValidationContext context)
        {
            ValidationResult result = ValidationResult.Success;
            if(number > 100) //Only an example
            {
                return new ValidationResult("Number is too large.", new string[]{"Number"});
            }
            return result;
        }
    }
