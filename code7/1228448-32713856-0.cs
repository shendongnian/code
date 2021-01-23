    public class customvalidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string email = value.ToString();
                    if (Regex.IsMatch(email, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", RegexOptions.IgnoreCase))
                    {
                        return ValidationResult.Success;
                    }
                    else if (Regex.IsMatch(email, @"(\d*-)?\d{10}", RegexOptions.IgnoreCase))
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Invalid EmailID or Mobile Number");
                    }
    
                }
                else
                {
                    return new ValidationResult("" + validationContext.DisplayName + "is required");
                }
                //return base.IsValid(value, validationContext);
            }
    
        }
