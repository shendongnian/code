    public static class ValidationExtensions
    {
        public static void ValidateAndThrow<T>(this IValidator<T> validator, T instance, string ruleSet)
        {
            var result = validator.Validate(instance, ruleSet: ruleSet);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
