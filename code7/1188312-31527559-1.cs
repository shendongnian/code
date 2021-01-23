    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var context = (G9EntityDataBaseClass)validationContext.Items["Context"];
        if (context.User
                   .Where(u => u.email == email && u.UserID != this.UserID)
                   .Any())
        {
            return new ValidationResult(ErrorMessageString);
        }
        else
        {
            return ValidationResult.Success;
        }
    }
