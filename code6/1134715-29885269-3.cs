    public IEnumerable<ValidationResult> IValidatableObject.Validate(
      ValidationContext validationContext)
    {
      var context = new ValidationContext(this) { MemberName = nameof(BirthDate) };
      var dateResults = new List<ValidationResult>();
      if (!Validator.TryValidateValue(this.BirthDate, context, dateResults,
        new[]
        { 
          new RequiredAttribute 
          {
            ErrorMessageResourceType = typeof(ValidationResx),
            ErrorMessageResourceName = Resx.Required 
          }
        }))
        foreach (var dateResult in dateResults)
          yield return dateResult;
    }
