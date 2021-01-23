    public override IEnumerable<ValidationResult> Validate(User entity)
    {
        if (entity == null)        
            throw new ArgumentNullException();        
        return UserValidationIterator(entity);
    }
    private IEnumerable<ValidationResult> UserValidationIterator(User user)
    {
        if (entity.BirthDate == DateTime.MinValue)
           yield return new ValidationResult("User", "BirthDate is mandatory");
        // other yields here
    }
