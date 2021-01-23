    var instance = new MyDto { SomeProperty = null };
    var context = new ValidationContext(instance);
    var validationResults = new List<ValidationResult>();
    Validator.TryValidateObject(instance, context, validationResults, validateAllProperties: true);
    var errors = validationResults.Where(r => r != ValidationResult.Success);
    if (errors.Any())
    {
        //do whatever you like to do
    }
