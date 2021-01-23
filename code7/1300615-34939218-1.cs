    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
 
    .
    .
    .
    Post post = ... // fill it in
    if (GetValidationErrors(post).Any())
    {
        throw new MyCustomException();
    }
	public static IEnumerable<ValidationResult> GetValidationErrors(this object obj)
	{
		var validationResults = new List<ValidationResult>();
		var context = new ValidationContext(obj, null, null);
		Validator.TryValidateObject(obj, context, validationResults, true);
		return validationResults;
	}
