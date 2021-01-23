    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
 
    .
    .
    .
    Post post = ... // fill it in
    Validator.Validate(post);
    public static class Validator
    {
        public static void Validate(this Post post)
        {
            // uses the extension method GetValidationErrors defined below
            if (post.GetValidationErrors().Any())
            {
                throw new MyCustomException();
            }
         }
    }
	public static class ValidationHelpers
	{
    	public static IEnumerable<ValidationResult> GetValidationErrors(this object obj)
	    {
		    var validationResults = new List<ValidationResult>();
		    var context = new ValidationContext(obj, null, null);
		    Validator.TryValidateObject(obj, context, validationResults, true);
		    return validationResults;
	    }
    .
    .
    .
