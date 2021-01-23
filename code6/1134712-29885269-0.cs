    public IValidatableObject.IEnumerable<ValidationResult> Validate(
      ValidationContext validationContext)
    {
      var context = new ValidationContext(this) { MemberName = "BirthDate" };
      var dateResults = new List<ValidationResult>();
      if (!Validator.TryValidateValue(BirthDate, context, dateResults, 
            new[] { new RequiredAttribute 
                    {
                      ErrorMessageResourceType = typeof(ValidationResx),
                      ErrorMessageResourceName = Resx.Required
                    } }))
        foreach (var dateResult in dateResults)
          yield return dateResult;
    }
