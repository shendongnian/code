    public sealed class Resolver : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = (IProvideValueTarget)serviceProvider
                .GetService(typeof(IProvideValueTarget));
            // Find the type of the property we are resolving
            var targetProperty = provideValueTarget.TargetProperty as PropertyInfo;
            if (targetProperty == null)
            {
                throw new InvalidProgramException();
            }
            // Find the implementation of the type in the container
            return BootStrapper.Container.Resolve(targetProperty.PropertyType);
        }
    }
