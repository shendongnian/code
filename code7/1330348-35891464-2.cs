    public class FooValidator : AbstractValidator<Foo>
    {
        public FooValidator(Foo obj)
        {
            // Iterate properties using reflection
            var properties = ReflectionHelper.GetShallowPropertiesInfo(obj);
            foreach (var prop in properties)
            {
                // Create rule for each property, based on some data coming from other service...
                RuleFor(o => o)
                    .CustomNotEmpty(obj.GetType().GetProperty(prop.Name))
                    .When(o =>
                {
                    return true; // do other stuff...
                });
            }
        }
    }
