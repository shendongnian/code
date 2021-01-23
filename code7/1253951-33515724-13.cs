    /// <summary>
    /// Adds an unregistered type resolution for objects missing an IValidator.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    internal sealed class ValidateNothingDecorator<T> : AbstractValidator<T>
    {
    	// I do nothing :-)
    }
    	
    // Add unregistered type resolution for objects missing an IValidator<T>
    // This should be placed after the registration of IValidator<>
    container.RegisterConditional(typeof(IValidator<>), typeof(ValidateNothingDecorator<>), Lifestyle.Singleton, context => !context.Handled);
