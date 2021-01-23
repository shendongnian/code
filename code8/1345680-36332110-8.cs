    var instance = new MyDto { SomeProperty = null }; //note that I'm setting the property to null, while the property has the Required attribute
    var context = new ValidationContext(instance);
    var validationResults = new List<ValidationResult>(); //this list will contain all validation results
    Validator.TryValidateObject(instance, context, validationResults, validateAllProperties: true);
    var errors = validationResults.Where(r => r != ValidationResult.Success); //filter out all successful results since we are only interested in errors
    if (errors.Any())
    {
        //do whatever you like to do
    }
