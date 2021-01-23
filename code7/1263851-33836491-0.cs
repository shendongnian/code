    public class CustomAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj = object as Register;
            if(obj.Status == 1)
                return return ValidationResult.Success;
            //else perform additional check 
        }
    }
