    public static void ValidateAndThrow<T>(this IValidator<T> validator, T instance)
    {
        var result = validator.Validate(instance);
	    if(! result.IsValid)
        {
			throw new ValidationException(result.Errors);	
		}
	}
