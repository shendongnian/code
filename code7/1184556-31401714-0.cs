    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(Mobile) || string.IsNullOrEmpty(Email))
        {
             yield return new ValidationResult("Some error message");
        } 
    }
