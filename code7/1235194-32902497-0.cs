    public class MyValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            switch (validationContext.MemberName)
            {
                //some logic
            }
        }
    }
